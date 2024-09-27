using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Basic Controls
    private float horizontal;
    private bool isFacingRight = true;

    [SerializeField] private float Move_check_size = .5f;


    [SerializeField] private float speed = 5f;

    [SerializeField] private Rigidbody2D rb;

    // Jumping
    [SerializeField] private float jumpPower = 20f;
    private bool doubleJump;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Dashing
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 10f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCoolDown = 1f;

    [SerializeField] private TrailRenderer trailRenderer;

    // Wall Slide
    private bool isWallSliding;
    [SerializeField] private float wallSlidingSpeed = 2f;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    // Wall Jump
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingCounter;
    [SerializeField] private float wallJumpingTime = 2f;
    [SerializeField] private float wallJumpingDuration = 0.15f;
    [SerializeField] private Vector2 wallJumpingPower = new (2f, 16f);

    // Coyote Time
    private float coyoteTimeCounter;
    [SerializeField] private float coyoteTime = 0.15f;


    // Animator
    Animator myAnimator;

    private void Start() {
        myAnimator = GetComponent<Animator>();
    }















    private void Update()
    {
        if (isDashing)
        {
            return;
        }


        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        Run();
        Jump();
        WallSlide();
        WallJump();


        if (!isWallJumping)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizontal != 0f)
        {
            StartCoroutine(Dash());
        }
    }




    private void FixedUpdate()
    {
        Flip();


        if (isDashing)
        {
            return;
        }

        if (!isWallJumping)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }


    void Run(){
        horizontal = Input.GetAxisRaw("Horizontal");

        //bool playerhasvelocity = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(horizontal !=0 && !IsWalled()){
            myAnimator.SetBool("isRunning", true);
        }
        else{
            myAnimator.SetBool("isRunning", false);
        }
        
    }




















    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, Move_check_size, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, Move_check_size, wallLayer);
    }












    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }














    private void Jump()
    {
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump") && (coyoteTimeCounter > 0 || doubleJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            doubleJump = !doubleJump;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }













    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;


        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);

        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;

        isDashing = false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;
    }











    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }













    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }










    private void StopWallJumping()
    {
        isWallJumping = false;
    }






    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            int currentSceneindex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneindex);
        }
    }


    void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<ParticleSystem>() != null)
        {
            // Restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }






}

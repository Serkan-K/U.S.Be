using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThing : MonoBehaviour
{
    
    private bool playerOnPlatform = false;
    [SerializeField] private float duration = 5f;
    [SerializeField] private float duration2 = 2f;
    private float timer;
    private float timer2;
    private bool flag = false;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer = duration;
            playerOnPlatform = true;
            timer2 = duration2;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnPlatform = false;
            timer = duration;
            // Reactivate components
            /*if (rb != null)
                rb.simulated = true;*/

            /*if (coll != null)
                coll.enabled = true;

            if (spriteRenderer != null)
                spriteRenderer.enabled = true;*/
        }
    }

    void Respawning()
    {
        timer2 -= Time.deltaTime;
        Debug.Log("girdimsadasd");
        if (timer2 <= 0)
        {
            Debug.Log("girdim");
            // Reactivate components
            rb.simulated = true;

            coll.enabled = true;

            spriteRenderer.enabled = true;
            flag = false;
        }
    }

    void Update()
    {
        if (playerOnPlatform)
        {
            timer -= Time.deltaTime;
            Debug.Log("anamekan");
            if (timer <= 0)
            {
                // Deactivate components
                if (rb != null)
                    rb.simulated = false;

                if (coll != null)
                    coll.enabled = false;

                if (spriteRenderer != null)
                    spriteRenderer.enabled = false;
                
                flag = true;

                
            }
        }
        if(flag){
            Respawning();
        }
    }


}

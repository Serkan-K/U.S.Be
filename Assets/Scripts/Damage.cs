using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{

    [SerializeField] private ParticleSystem pS;


    private void Start()
    {
        pS = GetComponent<ParticleSystem>();
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }



    //private void OnParticleTrigger()
    //{
    //    if (gameObject.tag == "Enemy")
    //    {
    //        int currentSceneindex = SceneManager.GetActiveScene().buildIndex;
    //        SceneManager.LoadScene(currentSceneindex);
    //    }
    //}



}


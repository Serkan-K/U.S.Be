using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_Bubble : MonoBehaviour
{

    [SerializeField] private int startDelay = 2;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float warningDelay = 0.5f;

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private ParticleSystem ps;


    private void Start()
    {
        InvokeRepeating("Blink_Red", startDelay, spawnInterval);

        sr = GetComponent<SpriteRenderer>();
        ps=GetComponent<ParticleSystem>();


    }


    private void Blink_Red()
    {
        StartCoroutine(Blink(5, warningDelay, 0.1f));
    }



    IEnumerator Blink(int loopCount, float delay, float blink)
    {

        while (loopCount > 0)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(blink);
            sr.color = Color.white;
            yield return new WaitForSeconds(blink);

            loopCount--;

        }

        yield return new WaitForSeconds(delay);

        Gaiser();

    }




    void Gaiser()
    {
        ps.Play();
    }

}
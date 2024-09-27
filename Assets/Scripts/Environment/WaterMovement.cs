using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float waterStartPos = 0.5f;   // Oyuncu bu y�ksekli�i ge�ince su hareketi ba�layacak
    [SerializeField] float waterShakeTime = 0.2f;
    [SerializeField] float increasingSpeed = 0.5f;
    [SerializeField] float shakeMagnitude = 0.1f;
    [SerializeField] private Transform cam;

    private bool shake = false;


    private void Update()
    {
        if (player.position.y > waterStartPos)
        {
            if(!shake)
            {
                //StartCoroutine(Shake());
            }
            IncreaseWaterLevel();
        }
    }

    IEnumerator Shake()
    {
        shake = true;
        float originalY = cam.position.y;
        for(float t = 0f; t < waterShakeTime; t+= Time.deltaTime)
        {
            float yOffset = UnityEngine.Random.Range(-shakeMagnitude, shakeMagnitude);
            cam.position = new Vector3(cam.position.x, originalY + yOffset, cam.position.z);
            yield return null;
        }
        cam.position = new Vector3(cam.position.x, originalY, cam.position.z);
        shake = false;
    }

    void IncreaseWaterLevel ()
    {
        transform.Translate (Vector3.up* increasingSpeed*Time.deltaTime);
    }
}

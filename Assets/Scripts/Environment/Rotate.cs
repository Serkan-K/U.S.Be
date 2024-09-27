using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;



    private void Start() {
        StartCoroutine(Rotate_Left());
        
    }     


    private IEnumerator Rotate_Left()
    {
        while (true)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.back, Space.Self);

            yield return null;

        }

    }

}

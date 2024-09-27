using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;


    private void Start()
    {
        StartCoroutine(Rotate_Right());
    }


    private IEnumerator Rotate_Right()
    {
        while (true)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.back, Space.Self);

            yield return null;

        }

    }
}

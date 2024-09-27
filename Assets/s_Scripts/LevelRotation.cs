using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float rotationAcceleration = 10f;

    [SerializeField] private new Transform transform;

    private void Update()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            Rotate_Right();
        }

        if (Input.GetKey(KeyCode.E))
        {
            Rotate_Left();
        }


    }




    private void Rotate_Left()
    {
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime * rotationAcceleration);
    }


    private void Rotate_Right()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * rotationAcceleration );
    }













    //private IEnumerator Rotate_Left()
    //{
    //    while (true)
    //    {
    //        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.back, Space.World);

    //        yield return null;

    //    }

    //}


    //private IEnumerator Rotate_Right()
    //{
    //    while (true)
    //    {
    //        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward, Space.World);

    //        yield return null;
    //    }
    //}




}
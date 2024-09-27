using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apperance : MonoBehaviour
{
    public GameObject objectToAppear;
    public float appearanceDelay = 2f; // Adjust the delay as needed

    void Start()
    {
        objectToAppear.SetActive(false);
        Invoke("ShowObject", appearanceDelay);
    }

    void ShowObject()
    {
        objectToAppear.SetActive(true);
    }
}

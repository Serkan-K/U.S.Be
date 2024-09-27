using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    [SerializeField] GameObject beceri;

    private void Start()
    {
        Destroy(beceri, 5f);
    }
}

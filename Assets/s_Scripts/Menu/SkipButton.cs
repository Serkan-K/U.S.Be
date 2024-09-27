using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipButton : MonoBehaviour
{
    [SerializeField] private GameObject skipButton;

    void Start()
    {
        StartCoroutine(Buttonappear());
    }

    IEnumerator Buttonappear()
    {
        yield return new WaitForSeconds(8);
        skipButton.SetActive(true);
    }
}

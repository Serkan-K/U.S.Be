using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer_Next_Level : MonoBehaviour
{
    [SerializeField] private float level_Time = 75f;


    private void Update()
    {
        level_Time -= Time.deltaTime;

        if (level_Time <= 0)
        {
            Load_Next_Level();
        }
    }

    public void Load_Next_Level()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel + 1);
    }



}

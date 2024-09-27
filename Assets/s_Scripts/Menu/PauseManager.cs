using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pause_Menu;
    bool Paused = false;


    public void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("DontDestroyTag");

        if (objects.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            Instantiate(pause_Menu);
            DontDestroyOnLoad(gameObject);
        }
    }





    void Update()
    {

        //if (SceneManager.GetSceneByName("0_Presents").isLoaded)
        //{
        //    pause_Menu.SetActive(false);
        //}







        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                pause_Menu.SetActive(false);
                //Cursor.visible = false;
                //Screen.lockCursor = true;
                //Camera.audio.Play();
                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                pause_Menu.SetActive(true);
                //Cursor.visible = true;
                //Screen.lockCursor = false;
                //Camera.audio.Pause();
                Paused = true;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pause_Menu.SetActive(false);
        //Cursor.visible = false;
        //Screen.lockCursor = true;
        //Camera.audio.Play();
        Paused = false;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}

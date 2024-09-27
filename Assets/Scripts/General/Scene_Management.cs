using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Management : MonoBehaviour
{
    public void Load_Start()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Load_Level_select()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Load_L1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void Load_L2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }

    public void Load_L3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }

    public void Quite_Game()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}

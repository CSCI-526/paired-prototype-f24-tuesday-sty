using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_ENV : MonoBehaviour
{
    bool disESC = false;
    public GameObject pulseUI;
    public GameObject loseUI;
    public GameObject winUI;
    public void showLoseUI()
    {
        disESC = true;
        loseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void showWinUI()
    {
        disESC = true;
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void showPulseUI()
    {
        if (pulseUI.activeSelf)
        {
            pulseUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pulseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Start()
    {
        Time.timeScale = 1f;
        pulseUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !disESC)
        {
            showPulseUI();
        }
    }
}

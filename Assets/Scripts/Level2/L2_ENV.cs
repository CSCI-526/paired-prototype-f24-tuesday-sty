using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_ENV : MonoBehaviour
{
    public GameObject objUI;
    // Start is called before the first frame update


    public void UICheck()
    {
        if (objUI.activeSelf)
        {
            objUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            objUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    void Start()
    {
        Time.timeScale = 1f;
        objUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UICheck();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1_ENV : MonoBehaviour
{
    public GameObject obstical;
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

    void ob_inact()
    {
        obstical.SetActive(false);
    }
    
    void Start()
    {
        Time.timeScale = 1f;
        objUI.SetActive(false);
        Invoke("ob_inact", 5f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UICheck();
        }
    }
}

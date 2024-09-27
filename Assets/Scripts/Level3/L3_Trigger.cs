using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3_Trigger : MonoBehaviour
{
    public GameObject obj;
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shadow")
        {
            if (obj.activeSelf)
            {
                obj.SetActive(false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Shadow")
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
            }
        }
    }
}

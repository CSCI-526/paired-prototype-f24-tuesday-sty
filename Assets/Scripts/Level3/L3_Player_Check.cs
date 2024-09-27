using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3_Player_Check : MonoBehaviour
{
    private L3_ENV L3EnvScript;
    private SpriteRenderer playerrenderer;
    private SpriteRenderer shadowrenderer;
    private bool buff = false;

    public GameObject envcontrol;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shadow"))
        {
            shadowrenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            playerrenderer = gameObject.GetComponent<SpriteRenderer>();

            if (shadowrenderer.color != playerrenderer.color)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                L3EnvScript.showLoseUI();
            }
            else
            {
                gameObject.GetComponent<PlayerController>().jumpforce *= 2;
                buff = true;
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            L3EnvScript.showLoseUI();
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            Destroy(collision.gameObject);
            L3EnvScript.showWinUI();
        }
    }

    private void Start()
    {
        L3EnvScript = envcontrol.GetComponent<L3_ENV>();
    }

    private void p_back()
    {
        gameObject.GetComponent<PlayerController>().jumpforce /= 2;
    }

    private void Update()
    {
        if (buff)
        {
            Invoke("p_back", 5f);
            buff = false;
        }
    }
}

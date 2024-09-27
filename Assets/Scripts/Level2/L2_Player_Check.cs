using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_Player_Check : MonoBehaviour
{
    private L2_ENV L2EnvScript;
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
                L2EnvScript.showLoseUI();
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
            L2EnvScript.showLoseUI();
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            Destroy(collision.gameObject);
            L2EnvScript.showWinUI();
        }
    }

    private void Start()
    {
        L2EnvScript = envcontrol.GetComponent<L2_ENV>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1_Player_Checdk : MonoBehaviour
{
    private L1_ENV L1EnvScript;
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

            if(shadowrenderer.color != playerrenderer.color)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                L1EnvScript.showLoseUI();
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
            L1EnvScript.showLoseUI();
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            Destroy(collision.gameObject);
            L1EnvScript.showWinUI();
        }
    }

    private void Start()
    {
        L1EnvScript = envcontrol.GetComponent<L1_ENV>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player_rig;
    private float horizontalInput;
    private bool onGround;
    private float groundCheckRange = 0.05f;
    public float delayTime = 3f;


    public GameObject shadow;
    public float speed = 10;
    public float jumpforce = 10;
    public LayerMask groundlayer;
    public SpriteRenderer playerrenderer;
    public SpriteRenderer shadowrenderer;
    public float colorChangeInterval = 2f;

    private List<Vector3> recordedPositions = new List<Vector3>();
    private int delayFrames;
    private bool playerMovement = false;
    private bool shadowspawn = false;
    private float shadowStartTimer = 0f;
    private float colorChangeTimer = 0f;
    private int shadowColorIndex = 0;
    private int playerColorIndex = 0;


    private void GroundCheck()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -0.5f), groundCheckRange, groundlayer);
    }

    private void PlayerControl()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (!playerMovement && (horizontalInput != 0 || Input.GetKeyDown(KeyCode.Space)))
        {
            playerMovement = true; // player started moving
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerColor();
        }

        if (playerMovement)
        {
            player_rig.velocity = new Vector2(horizontalInput * speed, player_rig.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                player_rig.velocity = new Vector2(player_rig.velocity.x, jumpforce);
            }

            recordedPositions.Add(transform.position);

            if (!shadowspawn)
            {
                shadowStartTimer += Time.deltaTime;
                if (shadowStartTimer >= delayTime)
                {
                    shadowspawn = true;
                }
            }
        }
    }

    private void shadowColor()
    {
        colorChangeTimer += Time.deltaTime;
        if (colorChangeTimer >= colorChangeInterval)
        {
            colorChangeTimer = 0f;
            switch (shadowColorIndex)
            {
                case 0:
                    shadowrenderer.color = Color.red; //Red
                    break;
                case 1:
                    shadowrenderer.color = Color.green; //Green
                    break;
                case 2:
                    shadowrenderer.color = Color.blue; //Blue
                    break;
            }
            shadowColorIndex = (shadowColorIndex + 1) % 3;
        }
    }

    private void playerColor()
    {
        switch (playerColorIndex)
        {
            case 0:
                playerrenderer.color = Color.red; // Red
                break;
            case 1:
                playerrenderer.color = Color.green; // Green
                break;
            case 2:
                playerrenderer.color = Color.blue; // Blue
                break;
        }
        playerColorIndex = (playerColorIndex + 1) % 3;
    }

    private void ShadowControl()
    {
        if (shadowspawn && recordedPositions.Count > delayFrames && shadow != null && Time.timeScale == 1f)
        {

            if (!shadow.activeSelf)
            {
                shadow.transform.position = recordedPositions[0];
                recordedPositions.RemoveAt(0);
                shadow.SetActive(true);
            }
            else
            {
                shadow.transform.position = recordedPositions[0];
                shadowColor();
                recordedPositions.RemoveAt(0);
            }
        }
    }

    void Start()
    {
        player_rig = GetComponent<Rigidbody2D>();
        delayFrames = Mathf.RoundToInt(delayTime / Time.deltaTime);
        shadow.SetActive(false);
    }

    void Update()
    {
        GroundCheck();
        PlayerControl();
        ShadowControl();
    }
}

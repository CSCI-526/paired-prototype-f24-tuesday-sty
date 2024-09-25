using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player_rig;
    private float horizontalInput;

    public float speed = 10;
    public float jumpforce = 10;

    // Start is called before the first frame update
    void Start()
    {
        player_rig = GetComponent<Rigidbody2D>();
    }

    void Playermove()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_rig.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }

        player_rig.velocity = new Vector2(horizontalInput * speed, player_rig.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        Playermove();
    }
}

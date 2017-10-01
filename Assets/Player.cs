using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerSpeed = 4;
    public float jumpHeight = 3;
    Rigidbody2D rb;
    bool runMode = true;
    bool canJump = true;

    public float scale = 0.5f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (runMode)
        {
            if (Input.GetKey("right"))
            {
                rb.velocity = new Vector3(playerSpeed, rb.velocity.y, 0);
                transform.localScale = new Vector3(scale, scale, 1);
            }
            else if(Input.GetKey("left"))
            {
                rb.velocity = new Vector3(-1*playerSpeed, rb.velocity.y, 0);
                transform.localScale = new Vector3(-1 * scale, scale, 1);
            }
            if(Input.GetKeyDown("space") && canJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, 0);
                canJump = false;
            }
        }
	}

    void ClimbingWallStart()
    {
        runMode = false;
        rb.simulated = false;
    }

    void ClimbingWallEnd()
    {
        runMode = true;
        rb.velocity = new Vector3(0, 0, 0);
        rb.simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canJump = false;
        }
    }
}

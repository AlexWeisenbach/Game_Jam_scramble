using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerSpeed = 4;
    public float jumpHeight = 3;
    Rigidbody2D rb;
    bool runMode = true;
    bool canJump = true;


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
            }
            else if(Input.GetKey("left"))
            {
                rb.velocity = new Vector3(-1*playerSpeed, rb.velocity.y, 0);
            }
            if(Input.GetKeyDown("space") && canJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, 0);
                canJump - false;
            }
        }
	}
}

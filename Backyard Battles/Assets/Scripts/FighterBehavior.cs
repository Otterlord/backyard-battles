using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBehavior : MonoBehaviour {
    // Player movement
    public float acceleration;
    public float force;
    public float jumpForce;

    private Rigidbody2D rb;
    public float weakness = 1;

    // Key bindings
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    private bool leftPressed;
    private bool rightPressed;
    private bool jumpPress;
    private bool jumpRelease;

    private bool hit;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
    void Update ()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position - new Vector3(0, 0.5f), Vector2.down, 0.5f);
        hit = raycastHit.collider != null;
        Debug.DrawRay(transform.position - new Vector3(0, 0.5f), Vector2.down * 0.5f, Color.red);
        if (Input.GetKey(leftKey)) leftPressed = true;
        else leftPressed = false;
        if (Input.GetKey(rightKey)) rightPressed = true;
        else rightPressed = false;
        if (Input.GetKeyDown(jumpKey)) jumpPress = true;
        if (Input.GetKeyUp(jumpKey))
        {
            jumpRelease = true;
        }
        else jumpRelease = false;

        /*
        if (rb.velocity.y <= 0)
        {
            rb.gravityScale = 2;
            print("hey okay");
        }
        else rb.gravityScale = 1;
        */
    }

    void FixedUpdate()
    {
        // Get input
        int dir = Convert.ToInt32(rightPressed) - Convert.ToInt32(leftPressed);

        // React to input
        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, dir * force, acceleration * Time.deltaTime), rb.velocity.y);
       
        if (jumpPress)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpPress = false;
        }
        else if (jumpRelease && rb.velocity.y > 3)
        {
            jumpRelease = false;
            rb.velocity = new Vector2(rb.velocity.x, 3);
        }
    }
}

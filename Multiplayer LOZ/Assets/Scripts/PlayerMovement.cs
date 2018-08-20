using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float walkSpd;
    [SerializeField] private float runSpd;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.Z)) Move(runSpd);
        else Move(walkSpd);
	}

    void Move(float spd)
    {
        Vector2 velocity = Vector2.zero;
        velocity.x = Input.GetAxisRaw("Horizontal") * spd;
        velocity.y = Input.GetAxisRaw("Vertical") * spd;

        velocity = Vector2.ClampMagnitude(velocity, spd);

        rb.velocity = velocity;
    } 
}

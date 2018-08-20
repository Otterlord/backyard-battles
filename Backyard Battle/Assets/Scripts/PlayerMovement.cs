using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private CharacterController controller;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float spd;
    [SerializeField]
    private float runSpd;
    [SerializeField]
    private float grv;
    [SerializeField]
    private float topGrv;
    [SerializeField]
    private float minGrv;
    [SerializeField]
    private float jumpHeight;

	void Start () {
        // Init some variables
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        // Get input
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        Vector3 normalized = Vector3.Normalize(new Vector3(Mathf.Abs(horInput), 0, Mathf.Abs(verInput)));

        velocity.x = spd * horInput;
        velocity.z = spd * verInput;

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump")) velocity.y = jumpHeight;
            else velocity.y = -minGrv;
        }
        else
        {
            if (velocity.y < -topGrv) velocity.y = -topGrv;
            else velocity.y -= grv;
        }

        // Normalize movement vector
        velocity = new Vector3(normalized.x * velocity.x, velocity.y, normalized.z * velocity.z);

        // Move relative to rotation
        velocity = transform.TransformDirection(velocity);

        // Apply movement
        controller.Move(velocity * Time.deltaTime);
	}
}

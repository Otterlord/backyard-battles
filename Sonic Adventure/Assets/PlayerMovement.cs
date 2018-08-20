using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float acc;
    public float dec;
    public float frc;
    public float top;
    private float currentSpd;

    public float jmp;

    public float grv;
    public float minGrv;
    public float topGrv;
    private CharacterController controller;


    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = Vector3.zero;

        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        if (horInput !=0 || verInput != 0)
        {

            velocity = new Vector3(horInput, 0, verInput);
            velocity = Vector3.ClampMagnitude(velocity, acc);

            transform.forward = transform.TransformDirection(velocity);
            //velocity = transform.TransformDirection(velocity);
            //print(velocity);
        }

        controller.Move(velocity * Time.deltaTime);
	}
}

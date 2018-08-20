using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {
    [SerializeField]
    private float sensitivity;
	
	// Update is called once per frame
	void Update () {
        float input = Input.GetAxis("Mouse X");

        transform.Rotate(sensitivity * input * Vector3.up);
	}
}

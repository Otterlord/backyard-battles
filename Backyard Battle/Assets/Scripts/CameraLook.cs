using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private float min;
    [SerializeField]
    private float max;

    private float rot = 0;
	
	// Update is called once per frame
	void Update () {
        float input = -Input.GetAxis("Mouse Y");
        // transform.Rotate(Vector3.right * sensitivity * input);
        rot += sensitivity * input;
        rot = Mathf.Clamp(rot, min, max);

        transform.localEulerAngles = new Vector3(rot, transform.localEulerAngles.y, 0);
        // transform.rotation = rotation;
	}
}

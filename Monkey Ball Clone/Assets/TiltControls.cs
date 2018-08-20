using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControls : MonoBehaviour {
    public float spd;
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(Input.GetAxis("Vertical") * spd, 0, -Input.GetAxis("Horizontal") * spd);
        
	}
}

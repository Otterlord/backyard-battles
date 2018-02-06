using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
    [SerializeField] private Transform target;

    private Vector3 velocity = Vector3.zero;

    public float amount = 0.4f;
    private

	void FixedUpdate () {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, amount);
	}
}

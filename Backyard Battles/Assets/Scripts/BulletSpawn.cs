using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour {
    public GameObject bullet;
    public float rotSpd = 10;
    public float bulletSpd = 2;
    public Vector3 offset;
	
	// Update is called once per frame
	void Update () {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos.z = -Camera.main.transform.position.z;
        Vector3 fixed_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        print(fixed_pos);
        transform.up = fixed_pos - transform.position;
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = GameObject.Instantiate(bullet);
            newBullet.transform.position = transform.position + (transform.up);
            newBullet.transform.rotation = transform.rotation;
            newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpd, ForceMode2D.Impulse);
        }
	}
}

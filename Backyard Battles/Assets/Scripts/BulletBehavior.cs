using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    public float damageAmount = 2;
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fighter")
        {
            // something here
        }
        if (other.tag != "Bullet") Destroy(this.gameObject);
    }
}

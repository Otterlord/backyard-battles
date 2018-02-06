using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    public float damageAmount = 2;
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fighter")
        {
            Vector2 direction = other.transform.position - transform.position;
            print(direction);
            other.GetComponent<Rigidbody2D>().AddForce(direction * 2 * other.GetComponent<FighterBehavior>().weakness, ForceMode2D.Impulse);
            other.GetComponent<FighterBehavior>().weakness += damageAmount;
        }
        if (other.tag != "Bullet") Destroy(this.gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float travelSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		Vector2 velocity = rigidbody2D.velocity;
		velocity.x = travelSpeed;
		rigidbody2D.velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "Ground") {
			Debug.Log("hit the ground!");
			Destroy(gameObject);
		}
		else if (collision.collider.tag == "Enemy") {
			Debug.Log("hit an enemy!");
			collision.collider.gameObject.GetComponent<Health>().Hit();
			Destroy(gameObject);
		}
	}
}

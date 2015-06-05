using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float velocity = 1.0f; //how fast does Trogdor walk?	
	//how much of his velocity does he lose per frame after you let go of the button?
	public float deceleration = 0.1f;
	public float jumpSpeed = 1.0f; //what is his initial jump velocity?
	
	bool canJump;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		Vector2 currentVelocity = rigidbody2D.velocity;
		float horizontal = Input.GetAxis("Horizontal");
		if (horizontal != 0) {
			currentVelocity.x = horizontal * velocity;
		}
		else {
			float deceleratedX = currentVelocity.x * deceleration;
			currentVelocity.x = deceleratedX <= 0.1f ? 0 : deceleratedX;
		}
		if (canJump && Input.GetKeyDown(KeyCode.Space)) {
			canJump = false;
			currentVelocity.y = jumpSpeed;
		}
		rigidbody2D.velocity = currentVelocity;
	}
	
	void OnCollisionStay2D(Collision2D collision) {
		if (collision.collider.tag == "Ground") {
			canJump = true; //when Trogdor is on the ground, he's allowed to jump
		}
	}
}

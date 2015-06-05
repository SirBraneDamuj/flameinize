using UnityEngine;
using System.Collections;

public class ExampleBehaviour : MonoBehaviour {	
	//this value can be changed in the inspector
	public float interval = 3.0f;
	public float jumpSpeed = 10.0f;
	
	float _timer;

	// Use this for initialization
	void Start () {
		_timer = interval;
	}
	
	// Update is called periodically (about once per frame)
	void Update () {
		_timer -= Time.deltaTime; //deltaTime = time elapsed since last Update
		if(_timer <= 0) {
			Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
			Vector2 velocity = rigidbody2D.velocity;
			velocity.y = jumpSpeed;
			rigidbody2D.velocity = velocity;
			_timer = interval;
		}
	}
}

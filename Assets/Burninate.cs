using UnityEngine;
using System.Collections;

public class Burninate : MonoBehaviour {
	public GameObject fireball;
	public Transform position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			shootFire();
		}
	}
	
	void shootFire() {
		
		Instantiate(fireball, position.position, Quaternion.identity);
	}
}

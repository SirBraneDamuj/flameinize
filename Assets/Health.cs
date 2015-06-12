using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int maxHealth;
	public ParticleSystem particles;
	
	bool _IDied;
	float _DeathTimer;
	int _health;
	Vector2 initialScale;

	// Use this for initialization
	void Start () {
		_health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (_IDied) {
			_DeathTimer -= Time.deltaTime;
			Vector2 scale = Vector2.Lerp(Vector2.zero, initialScale, _DeathTimer/2.0f);
			transform.localScale = scale;
			if (_DeathTimer <= 0.0f) {
				Destroy(gameObject);
			}
		}		
	}
	
	public void Hit() {
		_health--;
		if (_health <= 0) {
			particles.Play();
			_IDied = true;
			_DeathTimer = 2.0f;
			initialScale = transform.localScale;
		}
	}
	
}

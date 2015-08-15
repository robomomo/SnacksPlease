using UnityEngine;
using System.Collections;

public class ItemMover : MonoBehaviour {

	private bool isConstantVelocity;
	private bool isOneTimeForce;

	private float rotationRandom;

	private float gravityScale;
	private Vector2 velocity;

	private Rigidbody2D rb;

	private float speed;
	
	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Start() {
		if(isOneTimeForce)
			rb.gravityScale = gravityScale;

		rotationRandom = Random.Range (0f, 100f);
		speed = Random.Range (80f, 160f);
	}

	void FixedUpdate() {
		rb.velocity = velocity * Time.deltaTime * speed;
		rb.rotation += rotationRandom * Time.deltaTime;
	}


	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "MainCamera") {
			Reset ();
		}
	}

	public void Reset() {
		gameObject.SetActive (false);
		gameObject.transform.position = gameObject.transform.parent.position;
	}

	public void SetVelocity(Vector2 forceXRange, Vector2 forceYRange) {
		Vector2 vel = new Vector2(Random.Range(forceXRange.x, forceXRange.y), Random.Range(forceYRange.x, forceYRange.y));
		velocity = vel;
		speed = Random.Range (100f, 200f);
	}

	public void SetForce(Vector2 f) {
		isOneTimeForce = true;
	}

	public void SetGravityScale(float v) {
		gravityScale = v;
	}
}

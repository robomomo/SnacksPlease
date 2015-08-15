using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 0;
	
	public bool isMobileGame;
	public bool canPlayerMove = true;
	
	private Vector2 vel = Vector2.zero;
	private float rotation = 0;

	private bool isSpinning;

	private bool firstTouch;
	private Vector3 firstTouchPos;

	private Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();

		if (isMobileGame)
			speed = .35f * GlobalVars.MoveSpeedMultiplier;
		else
			speed = 1600f * GlobalVars.MoveSpeedMultiplier;
	}

	void CheckBounds() {

		Vector3 playerPosition = rb.position;

		// x collision
		if (playerPosition.x < Camera.main.ScreenToWorldPoint (new Vector2 (0f, 0f)).x || 
			playerPosition.x > Camera.main.ScreenToWorldPoint (new Vector2 (Camera.main.pixelWidth, 0f)).x) {
			rb.position = new Vector2 (
				Mathf.Clamp (
				rb.position.x, 
			             Camera.main.ScreenToWorldPoint (new Vector2 (0f, 0)).x, Camera.main.ScreenToWorldPoint (new Vector2 (Camera.main.pixelWidth, 0f)).x), rb.position.y);

		}

		// y collision
		if (playerPosition.y < Camera.main.ScreenToWorldPoint (new Vector2 (0f, 0f)).y || 
		    playerPosition.y > Camera.main.ScreenToWorldPoint (new Vector2 (0f, Camera.main.pixelHeight)).y) {
			rb.position = new Vector2(
				rb.position.x,
				Mathf.Clamp ( 
			             rb.position.y,   
			             Camera.main.ScreenToWorldPoint (new Vector2 (0f, 0f)).y, 
			             Camera.main.ScreenToWorldPoint (new Vector2 (0f, Camera.main.pixelHeight)).y));

		}
	}

	IEnumerator SpinPlayerOnce(float rotAmount) {
		while (rotAmount > rotation) {
			rotation += 1500f * Time.deltaTime;
			rb.rotation = rotation;
			isSpinning = true;

			yield return null;
		}

		gameObject.transform.rotation =  Quaternion.AngleAxis (0, Vector3.forward);
		rotation = 0;
		isSpinning = false;
	}

	IEnumerator SpinPlayer() {
		while (true) {
			
			rotation += 1500f * Time.deltaTime;
			rb.rotation = rotation;
			
			yield return null;
		}
	}

	public void Fall() {
		rb.velocity = Vector2.zero;
		vel.x = 0;
		vel.y -= 9f * Time.deltaTime;
	}


	void FixedUpdate() {
		if (canPlayerMove) {

			if (isMobileGame) {
				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
					// Get movement of the finger since last frame
					Touch t = Input.GetTouch (0);

					float dt = Time.deltaTime / t.deltaTime;
					if (dt == 0 || float.IsNaN (dt) || float.IsInfinity (dt))
						dt = 1.0f;


					vel = t.deltaPosition * dt * speed;
	
				} else {
					vel.x *= 0.8f;
					vel.y *= 0.8f;
		
				}
			} else {

				if (Input.GetMouseButton (0)) {
					firstTouchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					Vector3 mPos = (firstTouchPos - gameObject.transform.position).normalized;

					vel = mPos * Time.deltaTime * speed;
				} else {
					vel.x *= 0.8f;
					vel.y *= 0.8f;
				}
			}

			CheckBounds();
		}

		if (vel.x < 0)
			gameObject.transform.localScale = new Vector3 (-1, 1, 1);
		else {
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
		}
	
		rb.velocity = vel;

	
	}
}

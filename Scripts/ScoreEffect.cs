using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreEffect : MonoBehaviour {

	public List<Sprite> sprites = new List<Sprite> ();

	public int spriteIndex;

	public float moveSpeed;
	public float fadeSpeed;

	private Vector3 position;

	private SpriteRenderer spriteRenderer;
	private Color spriteColor;

	void Awake () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteColor = spriteRenderer.color;
		position = Vector3.zero;
		spriteIndex = 0;
	}

	void Update () {

		position = gameObject.transform.position;
		position.y += moveSpeed * Time.deltaTime;
		gameObject.transform.position = position;

		spriteColor.a -= fadeSpeed * Time.deltaTime;
		spriteRenderer.color = spriteColor;

		spriteRenderer.sprite = sprites [spriteIndex];


		if (spriteColor.a <= 0) {
			Destroy(this.gameObject);
		}
	}

	void LateUpdate() {
		gameObject.transform.rotation = Quaternion.identity;
	}

	public void SetPosition(Vector3 pos) {
		position = pos;
	}

	public void SetSprite(int index) {
		spriteIndex = index;
	}
}

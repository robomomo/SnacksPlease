using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveSpeedArrow : MonoBehaviour {

	public List<Sprite> sprites = new List<Sprite> ();

	public bool isRightArrow;
	public int maxSpeed;

	private float i;
	public float spinSpeed = 0.1f;

	private SpriteRenderer spriteRenderer;
	private AudioSource audioSource;
	
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void Update () {
		i += spinSpeed;
		gameObject.transform.Rotate(Vector3.forward * (Mathf.Sin (i) * spinSpeed));

	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {

			audioSource.Play();

			if(isRightArrow) {
				if(GlobalVars.MoveSpeedMultiplier < maxSpeed)
					GlobalVars.MoveSpeedMultiplier++;
			}
			else {
				if(GlobalVars.MoveSpeedMultiplier > 1)
					GlobalVars.MoveSpeedMultiplier--;
			}

			PlayerPrefs.SetInt ("speed_setting", GlobalVars.MoveSpeedMultiplier);
			spriteRenderer.sprite = sprites [1];
			StartCoroutine(ArrowUp());
		}
	}

	IEnumerator ArrowUp() {
		yield return new WaitForSeconds (0.3f);
		spriteRenderer.sprite = sprites [0];

	}
}

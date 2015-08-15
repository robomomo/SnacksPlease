using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerOnTitleScreen : MonoBehaviour {

	public List<Sprite> sprites = new List<Sprite> ();

	private SpriteRenderer spriteRenderer;
	private AudioSource audioSource;
	private SceneChange sceneChangeScript;

	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		audioSource = gameObject.GetComponent<AudioSource> ();

		GameObject[] screenFaders = GameObject.FindGameObjectsWithTag ("fade");
		foreach (GameObject go in screenFaders) {
			SceneChange script = go.GetComponent<SceneChange>();
			if(script.sceneTo == "Game") {
				sceneChangeScript = script;
			}
		}

	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			if(sceneChangeScript != null) {
				PlayerPrefs.Save();
				spriteRenderer.sprite = sprites [1];
				sceneChangeScript.BeginFade();
				audioSource.Play();
			}
			
		}
	}
}

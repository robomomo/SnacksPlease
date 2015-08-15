using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Score : MonoBehaviour {

	public List<Sprite> sprites = new List<Sprite> ();

	private List<SpriteRenderer> numbers = new List<SpriteRenderer> ();

	private bool scoreBounceDone = false;
	private bool scaleUp = false;

	void Awake () {
		if (Application.loadedLevelName == "Game") {
			GlobalVars.Score = 0;
			//GlobalVars.BestScore = PlayerPrefs.GetInt ("score");
		}

		for(int i = 0; i < gameObject.transform.childCount; i++)
		{
			Transform go = gameObject.transform.GetChild(i);
			numbers.Add(go.gameObject.GetComponent<SpriteRenderer>());
		}
	}
	
	void Update () {
		string scoreChars = GlobalVars.Score.ToString ("D4");
		for (int i = 0; i <= 3; i++) {
			numbers[i].sprite = sprites[(int)char.GetNumericValue(scoreChars[i])];
		}


	}

	public void AddToScore(int amount) {
		GlobalVars.Score += amount;
		scaleUp = true;
		scoreBounceDone = false;
		StartCoroutine (Bounce ());
	}

	IEnumerator Bounce() {
		while (!scoreBounceDone) {
			Vector3 scale = gameObject.transform.parent.gameObject.transform.localScale;
			if(scaleUp) {
				scale.x += 0.1f;
				scale.y += 0.1f;

				if(scale.x >= 2f) {
					scaleUp = false;

				}
			}
			else {
				scale.x -= 0.1f;
				scale.y -= 0.1f;

				if(scale.x <= 1) {
					scale.x = 1f;
					scale.y = 1f;
					scoreBounceDone = true;
				}
			}


			gameObject.transform.parent.gameObject.transform.localScale = scale;
			yield return null;
		}
	}
}

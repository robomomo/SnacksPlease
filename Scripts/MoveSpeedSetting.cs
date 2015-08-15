using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveSpeedSetting : MonoBehaviour {

	public List<GameObject> stars = new List<GameObject>();
	
	void Awake () {
		Transform starsContainer;

		for(int i = 0; i < gameObject.transform.childCount; i++) {

			if(gameObject.transform.GetChild(i).name == "Stars") {

				starsContainer = gameObject.transform.GetChild(i);

				for(int j = 0; j < starsContainer.transform.childCount; j++) {
					Transform go = starsContainer.transform.GetChild(j);
					SetColorBlack(go.gameObject);
					stars.Add(go.gameObject);
				}
			}
		}
	}

	void Start () {
		if(PlayerPrefs.GetInt ("speed_setting") <= 0)
			GlobalVars.MoveSpeedMultiplier = 3;
	}

	void SetColorBlack(GameObject go) {
		Color c = go.GetComponent<SpriteRenderer> ().color;
		c.r = 0;
		c.g = 0;
		c.b = 0;

		go.GetComponent<SpriteRenderer> ().color = c;
	}

	void SetColorNormal(GameObject go) {
		Color c = go.GetComponent<SpriteRenderer> ().color;
		c.r = 255;
		c.g = 255;
		c.b = 255;
		
		go.GetComponent<SpriteRenderer> ().color = c;
	}
	
	void Update () {
		for(int i = 0; i < stars.Count; i++) {
			if(i < GlobalVars.MoveSpeedMultiplier)
				SetColorNormal(stars[i]);
			else {
				SetColorBlack(stars[i]);
			}
		}
	}
}

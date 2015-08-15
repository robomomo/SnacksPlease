using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CandyOnTitleScreen : MonoBehaviour {

	public List<Sprite> sprites = new List<Sprite> ();
	private SpriteRenderer spriteRenderer;
	
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprites [0];
	}

	void Update () {
		if (GlobalVars.MoveSpeedMultiplier >= 6) {
			spriteRenderer.sprite = sprites [2];
		}
		else if(GlobalVars.MoveSpeedMultiplier <= 5 && GlobalVars.MoveSpeedMultiplier > 3) {
			spriteRenderer.sprite = sprites [1];
		}
		else if(GlobalVars.MoveSpeedMultiplier <= 3) {
			spriteRenderer.sprite = sprites [0];
		}
	}
}

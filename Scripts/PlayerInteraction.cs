using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public GameObject starParticle;
	public GameObject scoreEffect;

	private Color colorNormal;
	private Color colorBonus;

	private PlayerStatus playerStatusScript;
	private IconBox iconBoxScript;

	void Awake () {
		playerStatusScript = GetComponent<PlayerStatus> ();
		iconBoxScript = GameObject.FindGameObjectWithTag ("IconBox").GetComponent<IconBox> ();
		colorNormal = new Color (1, 1f, 1f);
		colorBonus = new Color (0f/255f, 172f/255f, 255f/255f);
	}

	void OnTriggerEnter2D(Collider2D other) {

		ItemMover itemMoverScript = other.gameObject.GetComponent<ItemMover> ();

		if (!playerStatusScript.isDead) {
			if (itemMoverScript != null) {

				itemMoverScript.Reset ();

				ScoreEffectEnum scoreEffectValue;
		
				if (iconBoxScript.activeIconName == other.gameObject.tag) {
					scoreEffectValue = iconBoxScript.Increment ();
					GotItemEffect(colorNormal, scoreEffectValue, false);
				} else if(other.gameObject.tag == "cake") {
					scoreEffectValue = iconBoxScript.IncrementCakeBonus ();
					GotItemEffect(colorBonus, scoreEffectValue, true);
				} else {
					playerStatusScript.TakeDamage ();
				}
			}
		}
	}

	void GotItemEffect(Color particleColor, ScoreEffectEnum scoreEffectValue, bool isCake) {
		starParticle.GetComponent<ParticleSystem>().startColor = particleColor;
		Instantiate (starParticle, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -1), gameObject.transform.rotation);


		GameObject scoreEffectPrefab = Instantiate 
			(scoreEffect, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -1), gameObject.transform.rotation) as GameObject;
		if (scoreEffectValue == ScoreEffectEnum.ten) {
			scoreEffectPrefab.GetComponent<ScoreEffect>().SetSprite(0);

		} else if(scoreEffectValue == ScoreEffectEnum.thirty) {
			scoreEffectPrefab.GetComponent<ScoreEffect>().SetSprite(1);

		}
		else if(scoreEffectValue == ScoreEffectEnum.hundred) {
			scoreEffectPrefab.GetComponent<ScoreEffect>().SetSprite(2);
		}

		StartCoroutine (playerStatusScript.BeHappy (isCake));
	}
		

}

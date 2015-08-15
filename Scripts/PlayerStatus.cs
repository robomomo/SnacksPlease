using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour {

	public List<Sprite> sprites = new List<Sprite> ();
	public int spriteIndex;
	
	public GameObject tooBadMessage;

	private int HP;
	private int maxHP = 3;
	private bool isHappy;
	public bool isDead = false;
	
	public AudioClip collectSound;
	public AudioClip collectCakeSound;
	public AudioClip hitSound;

	private SpriteRenderer spriteRenderer;
	private PlayerMove playerMoveScript;
	
	private SceneChange sceneChangeScript;

	private AudioSource audioSource;

	void Start() { 
		HP = maxHP;
		spriteIndex = 0;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		audioSource = gameObject.GetComponent<AudioSource> ();

		GameObject[] screenFaders = GameObject.FindGameObjectsWithTag ("fade");
		foreach (GameObject go in screenFaders) {
			SceneChange script = go.GetComponent<SceneChange>();
			if(script.sceneTo == "Title") {
				sceneChangeScript = script;
			}
		}

		playerMoveScript = GetComponent<PlayerMove> ();
	}
	
	void Update () {
		if (isDead) {
			DeathSequence();
		}

		ChangeSprite ();

	}

	void ChangeSprite() {
		if (!isHappy) {
			if (HP == 3) {
				spriteIndex = 0;
			
			} else if (HP == 2) {
				spriteIndex = 1;
			
			} else if (HP == 1) {
				spriteIndex = 2;
			
			}
		}
		
		spriteRenderer.sprite = sprites [spriteIndex];
	}

	public void TakeDamage() {
		HP--;

		audioSource.clip = hitSound;
		audioSource.Play ();

		if (HP <= 0 && !isDead) {
			isDead = true;
	
			playerMoveScript.Spin (720, true);
			playerMoveScript.canPlayerMove = false;
			DeathSequence();
		} else { 
			playerMoveScript.Spin (720, false);

		}

	}

	public IEnumerator BeHappy(bool isCake) {
		if(isCake)
			audioSource.clip = collectCakeSound;
		else
			audioSource.clip = collectSound;

		audioSource.Play ();
		isHappy = true;
		spriteIndex = 3;

		yield return new WaitForSeconds (1f);
		isHappy = false;
	}

	public void DeathSequence() {
		tooBadMessage.GetComponent<TooBadMessage> ().isGameOver = true;
		spriteIndex = 2;
		playerMoveScript.Fall ();

		if (GlobalVars.Score > GlobalVars.BestScore) {
			PlayerPrefs.SetInt ("score", GlobalVars.Score);
			GlobalVars.BestScore = GlobalVars.Score;
		}

		Social.ReportScore(GlobalVars.BestScore, ""omitted"", (bool success) => {
		
		});

		PlayerPrefs.Save ();
		StartCoroutine(TransitionToTitle());
	
	}

	IEnumerator TransitionToTitle() {
		yield return new WaitForSeconds (3f);

		sceneChangeScript.BeginFade();

	}
}

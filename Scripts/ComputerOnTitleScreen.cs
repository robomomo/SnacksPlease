using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class ComputerOnTitleScreen : MonoBehaviour {

	private AudioSource audioSource;
	
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			StartCoroutine(CallLeaderboard());
		}
	}

	IEnumerator CallLeaderboard() {
		audioSource.Play();
		yield return new WaitForSeconds (1f);
		PlayGamesPlatform.Instance.ShowLeaderboardUI(""omitted"");
	}
}

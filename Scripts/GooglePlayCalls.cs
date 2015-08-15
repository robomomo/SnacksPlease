using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayCalls : MonoBehaviour {
	
	void Awake () {
		PlayGamesPlatform.Activate();

		Social.localUser.Authenticate((bool success) => {
		
		});
	}
}

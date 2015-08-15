using UnityEngine;
using System.Collections;

public class CreateBlackTexture : MonoBehaviour {

	void Awake () {

		if (!GlobalVars.blackTextureCreated) {
			GlobalVars.blackTextureCreated = true;
			GameObject blackTexture = Instantiate (Resources.Load ("BlackTexture")) as GameObject;
			blackTexture.AddComponent<DontDestroy> ();
			blackTexture.tag = "black";
		}

		GameObject screenFader = Instantiate (Resources.Load ("ScreenFader")) as GameObject;
		SceneChange script = screenFader.GetComponent<SceneChange>();

		if(Application.loadedLevelName == "Title") {
			script.sceneTo = "Game";
		} else if (Application.loadedLevelName == "Game") {
			script.sceneTo = "Title";
		}
		screenFader.tag = "fade";
	}

}

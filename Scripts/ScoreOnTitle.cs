using UnityEngine;
using System.Collections;

public class ScoreOnTitle : MonoBehaviour {

	void Start () {
		GlobalVars.BestScore = PlayerPrefs.GetInt ("score");
		GlobalVars.Score = GlobalVars.BestScore;
	}

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ScoreEffectEnum {
	none,
	ten,
	thirty,
	hundred
}

public class IconBox : MonoBehaviour {

	public List<Sprite> possibleItems = new List<Sprite>();

	public GameObject speechBubbleItem;
	
	public string activeIconName;
	public int activeIndex;

	public GameObject scoreBox;

	private List<GameObject> icons = new List<GameObject> ();
	private Score scoreScript;
	
	void Awake () {
		scoreScript = scoreBox.GetComponent<Score> ();

		for(int i = 0; i < gameObject.transform.childCount; i++)
		{
			Transform go = gameObject.transform.GetChild(i);
			icons.Add(go.gameObject);
		}
	}
	
	void Start () {
		ResetIcons ();
		SetActiveIcon (0);
	}

	void Update () {
		icons [activeIndex].gameObject.transform.localScale = new Vector3 (
			Mathf.PingPong (Time.time, 0.4f) + 0.4f, Mathf.PingPong (Time.time, 0.4f) + 0.4f, 1
		);
	}

	void ResetIcons() {
		for(int i = 0; i < gameObject.transform.childCount; i++)
		{
			Transform go = gameObject.transform.GetChild(i);
			go.GetComponent<SpriteRenderer>().sprite = possibleItems[Random.Range(0, possibleItems.Count)];
		}

		activeIndex = 0;
		SetActiveIcon (0);

	}

	void SetActiveIcon(int index) {
		activeIndex = index;
		activeIconName = icons [activeIndex].GetComponent<SpriteRenderer> ().sprite.name;
		speechBubbleItem.GetComponent<SpriteRenderer> ().sprite = icons [activeIndex].GetComponent<SpriteRenderer> ().sprite;
	}

	public ScoreEffectEnum Increment() {
		icons [activeIndex].gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 1);
		if (activeIndex < icons.Count - 1) {
			scoreScript.AddToScore(10);
			SetActiveIcon(activeIndex+1);
			return ScoreEffectEnum.ten;
		} else {
			scoreScript.AddToScore(30);
			ResetIcons();
			return ScoreEffectEnum.thirty;
		}
	}

	public ScoreEffectEnum IncrementCakeBonus() {
		scoreScript.AddToScore(100);
		return ScoreEffectEnum.hundred;
	}
}

using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	public float speed;
	public Transform background;
	public Transform background2;

	private Sprite sprite;
	
	void Awake() {
		sprite = background.GetComponent<SpriteRenderer> ().sprite;
	}
	
	void Update () {

		MoveBackgrounds ();
	
		if (Camera.main.WorldToScreenPoint (background.transform.position).x < -CameraFit.screenWidth) {
			
			Vector3 positionBesideNextBackground = new Vector3(background2.transform.position.x + sprite.bounds.size.x, 0, 1);
			background.transform.position = positionBesideNextBackground;
		}
		
		if (Camera.main.WorldToScreenPoint (background2.transform.position).x < -CameraFit.screenWidth) {
			
			Vector3 positionBesideNextBackground = new Vector3(background.transform.position.x + sprite.bounds.size.x, 0, 1);
			background2.transform.position = positionBesideNextBackground;
		}
	}

	void MoveBackgrounds() {
		Vector3 newPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		newPos.x -= speed * Time.deltaTime;
		transform.position = newPos;
	}
}

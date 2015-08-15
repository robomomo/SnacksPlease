using UnityEngine;
using System.Collections;

public class TooBadMessage : MonoBehaviour {

	public bool isGameOver = false;
	public float speed;

	private Vector3 toPosition = new Vector3(0, 0, 1);

	void Update () {
		if (isGameOver) {
			gameObject.transform.position = Vector3.MoveTowards(
				gameObject.transform.position,
				toPosition,
				speed * Time.deltaTime);
		}
	}
}

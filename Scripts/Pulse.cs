using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {

	void Update () {
		gameObject.transform.localScale = new Vector3 (
			Mathf.PingPong (Time.time, 0.2f) + 1f, Mathf.PingPong (Time.time, 0.2f) + 1f, 1
			);

	}
}

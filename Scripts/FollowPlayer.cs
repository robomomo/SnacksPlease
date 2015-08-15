using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;
	
	void Update () {
		gameObject.transform.position = player.transform.position + offset;
	}
}

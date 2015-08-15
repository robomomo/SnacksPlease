using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ItemSpawner : MonoBehaviour {

	public enum Direction
	{
		none,
		left,
		right
	}
	
	public Vector2 forceXRange;
	public Vector2 forceYRange;

	public int itemAmount;
	public List<string> possibleItems = new List<string>();
	
	public List<GameObject> heldItems = new List<GameObject>();

	public Vector2 timeInterval;

	private float interval = 0f;
	private float coolDown = 0f;

	void Awake() {

		List<GameObject> items = new List<GameObject>();

		for (int i = 0; i < itemAmount; i++) {
			GameObject instance = Instantiate (Resources.Load (possibleItems[i], typeof(GameObject))) as GameObject;
			instance.SetActive (false);
			instance.gameObject.transform.parent = this.transform;
			instance.gameObject.transform.position = this.transform.position;
		
			instance.GetComponent<ItemMover>().SetVelocity(forceXRange, forceYRange);

			items.Add(instance);
		}

		System.Random rnd = new System.Random (Random.Range (0, 100));
		IEnumerable<GameObject> randomizedItems = from i in items orderby rnd.Next() select i as GameObject;
		foreach (GameObject g in randomizedItems) {
			heldItems.Add(g);
		};
	}
	
	void Start () {
		SetInterval ();
	}

	void Update () {
		coolDown += Time.deltaTime;

		if (coolDown > interval) {
			SpawnItem();
			SetInterval();
			coolDown = 0f;
		}
	}

	void SpawnItem() {
		foreach (GameObject go in heldItems) {
			if(go.activeSelf == false) {
				go.SetActive(true);
				go.GetComponent<ItemMover>().SetVelocity(forceXRange, forceYRange);
				break;
			}
		}
	}

	void SetInterval() {
		interval = Random.Range (timeInterval.x, timeInterval.y);
	}
}

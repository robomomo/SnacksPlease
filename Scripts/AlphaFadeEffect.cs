using UnityEngine;
using System.Collections;

public class AlphaFadeEffect : MonoBehaviour {

	public float speed = 0.1f;

	private SpriteRenderer spriteRenderer;
	private Color color;
	private float i;

	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		color = spriteRenderer.color;
	}

	void Update () {
		i += speed;
		color.a = Mathf.Sin (i);
		spriteRenderer.color = color;
	}
}

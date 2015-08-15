using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

	public string sceneTo;
	public float fadeSpeed = 1f; 

	private GUITexture guiTextureBlack;
	private Color textureColor;
	
	private bool isFadeIn;
	private bool isFadeOut;

	void Start () {
		guiTextureBlack = GameObject.FindGameObjectWithTag ("black").GetComponent<GUITexture> ();
		guiTextureBlack.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
		guiTextureBlack.color = textureColor;
	}
	
	void FadeOut() {
		textureColor.a += Time.deltaTime * fadeSpeed;
		guiTextureBlack.color = textureColor;

		
		if (guiTextureBlack.color.a >= 0.95f) {
			isFadeOut = false;
			isFadeIn = true;

			Application.LoadLevel (sceneTo);
		}
	}


	
	void FadeIn() {
		textureColor.a -= Time.deltaTime * fadeSpeed;
		guiTextureBlack.color = textureColor;

		if (guiTextureBlack.color.a <= 0.00f) {
			
			isFadeIn = false;
		}
	}

	public void BeginFade() {
	
		isFadeOut = true;
	}

	void Update () {
		if (isFadeOut) {
			FadeOut();
		}
		if (isFadeIn) {
			FadeIn();
		}
	}
}

using UnityEngine;
using System.Collections;

public class CameraFit : MonoBehaviour {

	public float aspectW;
	public float aspectH;

	public static float pixelsToUnits = 100f;
	public static float scale = 1f;

	public static float screenHeight;
	public static float screenWidth;

	public Vector2 nativeResolution = new Vector2(0, 0);
	
	void Awake () 
	{
		if (!GlobalVars.CameraSet) {
			
			// set the desired aspect ratio (the values in this example are
			// hard-coded for 16:9, but you could make them into public
			// variables instead so you can set them at design time)
			float targetaspect = aspectW / aspectH;
			
			// determine the game window's current aspect ratio
			float windowaspect = (float)Screen.width / (float)Screen.height;
			
			// current viewport height should be scaled by this amount
			float scaleheight = windowaspect / targetaspect;
			
			// obtain camera component so we can modify its viewport
			Camera camera = GetComponent<Camera> ();
			scale = Screen.height / nativeResolution.y;
			pixelsToUnits *= scale;
			camera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;

			GlobalVars.CameraSet = true;
		}

		
		screenHeight = 2f * Camera.main.orthographicSize;
		screenWidth = screenHeight * Camera.main.aspect;

		BoxCollider2D[] colliders = gameObject.GetComponents<BoxCollider2D> ();
		
		Vector3 S = new Vector2(aspectW, aspectH);
		colliders[0].size = S * 2;
	}
}

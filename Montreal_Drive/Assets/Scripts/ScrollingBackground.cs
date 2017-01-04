using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

	private const int MAX_NUM_BACKGROUNDS = 3;
	private float backgroundHeight;
	public ScrollingObject scrollingBackground;

	// Use this for initialization
	void Start () 
	{
		// Create the first background in the visible window
		backgroundHeight = scrollingBackground.GetComponent<SpriteRenderer> ().bounds.size.y;
		float topOfScreenY = Camera.main.orthographicSize;
		Vector3 initialBackgroundPos = new Vector3 (0, topOfScreenY, 0);
		Instantiate (scrollingBackground, initialBackgroundPos, Quaternion.identity);

		// Then create another background on top of that visible one.
		Vector3 secondBackgroundPos = initialBackgroundPos;
		secondBackgroundPos.y += backgroundHeight;
		Instantiate (scrollingBackground, secondBackgroundPos, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () 
	{
		createNewBackground ();
	}

	void createNewBackground()
	{
		GameObject[] listBackgrounds = GameObject.FindGameObjectsWithTag ("Background");
		int currentNumBackgrounds = listBackgrounds.Length;

		if (currentNumBackgrounds == 0) {
			return;
		}

		GameObject firstBackground = listBackgrounds [0];
		float firstBackPos_y = firstBackground.transform.position.y;

		// If at least half of the first background has passed through the bottom of the visible window
		// AND there are less than MAX_NUM_BACKGROUNDS backgrounds displayed...
		if (firstBackPos_y <= 0.0f && currentNumBackgrounds < MAX_NUM_BACKGROUNDS) {
			// Create a background on top of the latest background
			GameObject latestBackground = listBackgrounds [listBackgrounds.Length - 1];
			Vector3 latestBackgroundPos = latestBackground.transform.position;
			Vector3 newBackgroundPos = new Vector3 (latestBackgroundPos.x, latestBackgroundPos.y + backgroundHeight, latestBackgroundPos.z);
			Instantiate (scrollingBackground, newBackgroundPos, Quaternion.identity);
		}
	}
}

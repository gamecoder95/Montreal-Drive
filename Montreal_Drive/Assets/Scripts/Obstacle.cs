using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public float moveSpeedY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		scrollDown ();
	
	}

	void scrollDown ()
	{
		if (this.transform.position.y >= 0) {
			this.transform.position += new Vector3 (0, -moveSpeedY, 0);
		} else {
			Destroy (gameObject);
		}
	}


}

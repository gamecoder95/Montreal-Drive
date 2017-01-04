using UnityEngine;
using System.Collections;

public class ScrollingObject : MonoBehaviour {

	private float scrollSpeedY;
	private Rigidbody2D myRigidBody2D;
	private float lowerBoundCameraY;

	// Use this for initialization
	void Start () {

		scrollSpeedY = 2.0f;

		myRigidBody2D = this.GetComponent<Rigidbody2D> ();
		myRigidBody2D.velocity = new Vector2 (0, -scrollSpeedY);
		// orthographicSize is the camera's half size when in orthographic mode
		lowerBoundCameraY = -1 * Camera.main.orthographicSize;
	}

	// Update is called once per frame
	void Update () {

		destroyWhenOutOfBounds ();

	}

	void destroyWhenOutOfBounds ()
	{
		if (this.transform.position.y <= lowerBoundCameraY) {
			Destroy (gameObject);
		}
	}
}

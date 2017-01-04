using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public float moveSpeedX;
	private Rigidbody2D myRigidBody2D;

	private float rightCameraBoundX;
	private float leftCameraBoundX;

	// Use this for initialization
	void Start () {
		if (moveSpeedX < 0.0f) {
			moveSpeedX *= -1;
		}
		myRigidBody2D = this.GetComponent<Rigidbody2D> ();

		float halfWidth = this.GetComponent<SpriteRenderer> ().bounds.size.x / 2;
		rightCameraBoundX = Camera.main.orthographicSize - halfWidth;
		leftCameraBoundX = -1 * rightCameraBoundX;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void FixedUpdate()
	{
		moveCar ();
	}

	void moveCar()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			myRigidBody2D.velocity = new Vector2 (-moveSpeedX, 0);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			myRigidBody2D.velocity = new Vector2 (moveSpeedX, 0);
		} else {
			myRigidBody2D.velocity = Vector2.zero;
		}

		Vector3 currentPos = this.transform.position;
		if (currentPos.x >= rightCameraBoundX) {
			currentPos.x = rightCameraBoundX;
			this.transform.position = currentPos;
		} else if (currentPos.x <= leftCameraBoundX) {
			currentPos.x = leftCameraBoundX;
			this.transform.position = currentPos;
		}
	}


}

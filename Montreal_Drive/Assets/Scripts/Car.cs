using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public float moveSpeedX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveCar ();
	}

	void moveCar()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.position += new Vector3 (-moveSpeedX, 0, 0);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.position += new Vector3 (moveSpeedX, 0, 0);
		} 
	}


}

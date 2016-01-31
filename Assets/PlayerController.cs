using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D topLeft;
	public Rigidbody2D topRight;
	public Rigidbody2D bottomLeft;
	public Rigidbody2D bottomRight;
	public Vector2 topLeftForce;
	public Vector2 topRightForce;
	public Vector2 bottomLeftForce;
	public Vector2 bottomRightForce;

	// For debug purposes
	public bool[] buttons;

//	void Awake () {
//	}

	// Update is called once per frame
	void Update ()
	{
		bool[] tempButtons = {false, false, false, false};

		if (Input.GetButton("TopLeft"))
		{
			topLeft.AddRelativeForce(topLeftForce);
			tempButtons[0] = true;
		}

		if (Input.GetButton("TopRight"))
		{
			topRight.AddRelativeForce(topRightForce);
			tempButtons[1] = true;
		}

		if (Input.GetButton("BottomLeft"))
		{
			bottomLeft.AddRelativeForce(bottomLeftForce);
			tempButtons[2] = true;
		}

		if (Input.GetButton("BottomRight"))
		{
			bottomRight.AddRelativeForce(bottomRightForce);
			tempButtons[3] = true;
		}

		Array.Copy(tempButtons, buttons, 4);
	}
}

using UnityEngine;
using System.Collections.Generic;
using System;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D topLeft;
	public Rigidbody2D topRight;
	public Rigidbody2D bottomLeft;
	public Rigidbody2D bottomRight;

	public Vector2 topLeftForce;
	public Vector2 topRightForce;
	public Vector2 bottomLeftForce;
	public Vector2 bottomRightForce;

	public Transform[] flipperSprites;

	public Vector3 flipperRotation;
	public float flipperRotationDuration;

	// For debug purposes
	public bool[] buttons;

	List<Sequence> flipperWiggles;

	private Transform _transform;

	protected Transform MyTransform {
		get {
			if (_transform == null) {
				_transform = transform;
			}
			
			return _transform;
		}
	}

	void Start()
	{
		flipperWiggles = new List<Sequence>();
//		AutoPlay defaultAutoPlay = DOTween.defaultAutoPlay;
//		DOTween.defaultAutoPlay = AutoPlay.None;

		foreach (var flipper in flipperSprites)
		{
			Sequence flipperSequence = DOTween.Sequence().SetLoops(-1);
			flipperSequence.Append(flipper.DOLocalRotate(flipperRotation, flipperRotationDuration))
						   .Append(flipper.DOLocalRotate(Vector3.zero, flipperRotationDuration));
			flipperWiggles.Add(flipperSequence);
		}

		DOTween.PauseAll();
//		DOTween.defaultAutoPlay = defaultAutoPlay;
	}

	void PlayFlipperAnimation(int index)
	{
		if (!flipperWiggles[index].IsPlaying())
		{
			flipperWiggles[index].Play();
		}
	}

	// Update is called once per frame
	void Update ()
	{
		bool[] tempButtons = {false, false, false, false};

		if (Input.GetButton("TopLeft"))
		{
			topLeft.AddRelativeForce(topLeftForce);
			tempButtons[0] = true;

			PlayFlipperAnimation(0);
		}
		else
		{
			flipperWiggles[0].Pause();
		}

		if (Input.GetButton("TopRight"))
		{
			topRight.AddRelativeForce(topRightForce);
			tempButtons[1] = true;

			PlayFlipperAnimation(1);
		}
		else
		{
			flipperWiggles[1].Pause();
		}

		if (Input.GetButton("BottomLeft"))
		{
			bottomLeft.AddRelativeForce(bottomLeftForce);
			tempButtons[2] = true;

			PlayFlipperAnimation(2);
		}
		else
		{
			flipperWiggles[2].Pause();
		}

		if (Input.GetButton("BottomRight"))
		{
			bottomRight.AddRelativeForce(bottomRightForce);
			tempButtons[3] = true;

			PlayFlipperAnimation(3);
		}
		else
		{
			flipperWiggles[3].Pause();
		}

		Array.Copy(tempButtons, buttons, 4);
	}
}

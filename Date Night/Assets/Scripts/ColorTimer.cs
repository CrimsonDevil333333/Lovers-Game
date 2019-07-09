using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTimer : MonoBehaviour
{
	public float changeInterval = 1f;
	public bool isBlue = true;

	public Sprite blue;
	public Sprite pink;

	public GameObject blueLight;
	public GameObject pinkLight;

	public LayerMask blueMask;
	public LayerMask pinkMask;

	SpriteRenderer sr;
	PlatformEffector2D effector;

	float timeToChange;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		effector = GetComponent<PlatformEffector2D>();

		timeToChange = changeInterval;

		if (isBlue)
			MakeBlue();
		else
			MakePink();
	}

	private void Update()
	{
		if (Time.time >= timeToChange)
		{
			if (isBlue)
				MakePink();
			else
				MakeBlue();

			timeToChange = Time.time + changeInterval;
		}
	}

	void MakeBlue()
	{
		sr.sprite = blue;
		pinkLight.SetActive(false);
		blueLight.SetActive(true);
		gameObject.layer = LayerMask.NameToLayer("Blue");
		if (effector != null)
			effector.colliderMask = blueMask;
		isBlue = true;
	}

	void MakePink()
	{
		sr.sprite = pink;
		pinkLight.SetActive(true);
		blueLight.SetActive(false);
		gameObject.layer = LayerMask.NameToLayer("Pink");
		if (effector != null)
			effector.colliderMask = pinkMask;
		isBlue = false;
	}

}

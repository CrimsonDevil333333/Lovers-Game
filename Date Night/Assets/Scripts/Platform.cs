using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

	public Sprite blue;
	public Sprite pink;

	public GameObject blueLight;
	public GameObject pinkLight;

	public LayerMask blueMask;
	public LayerMask pinkMask;

	public bool isStandable = true;

	public bool isOutline = false;

	public bool makeBlue;
	public bool makePink;

	SpriteRenderer sr;
	PlatformEffector2D effector;

	private Sprite startSprite;
	private LayerMask startMask;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		effector = GetComponent<PlatformEffector2D>();

		startSprite = sr.sprite;
		if(effector != null)
			startMask = effector.colliderMask;

		if (makeBlue)
			MakeBlue();
		if (makePink)
			MakePink();
	}

	public void MakeBlue()
	{
		sr.sprite = blue;
		pinkLight.SetActive(false);
		blueLight.SetActive(true);
		gameObject.layer = LayerMask.NameToLayer("Blue");
		if (effector != null)
			effector.colliderMask = blueMask;
	}

	public void MakePink()
	{
		sr.sprite = pink;
		pinkLight.SetActive(true);
		blueLight.SetActive(false);
		gameObject.layer = LayerMask.NameToLayer("Pink");
		if (effector != null)
			effector.colliderMask = pinkMask;
	}

	public void Uncolor()
	{
		sr.sprite = startSprite;
		pinkLight.SetActive(false);
		blueLight.SetActive(false);
		if (isOutline)
			gameObject.layer = LayerMask.NameToLayer("Outline");
		else
			gameObject.layer = LayerMask.NameToLayer("Platform");
		if (effector != null)
			effector.colliderMask = startMask;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (isOutline)
			return;

		if (isStandable)
		{
			if (col.CompareTag("Player_BottomTrigger"))
			{
				string parentTag = col.transform.parent.tag;
				if (parentTag == "Player_Blue")
				{
					MakeBlue();
				}
				else if (parentTag == "Player_Pink")
				{
					MakePink();
				}
			}
		} else
		{
			if (col.CompareTag("Player_Blue"))
			{
				MakeBlue();
			}
			else if (col.CompareTag("Player_Pink"))
			{
				MakePink();
			}
		}
	}

}

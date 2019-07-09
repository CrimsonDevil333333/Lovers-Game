using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform_Button : MonoBehaviour
{
	public bool isPressed = false;

	public Animator animator;

	public UnityEvent OnPress;
	public UnityEvent OnUnPress;

	public bool hasBlue;
	public bool hasPink;

	void Press ()
	{
		isPressed = true;
		OnPress.Invoke();
		animator.SetBool("IsEnabled", true);
	}

	void UnPress()
	{
		isPressed = false;
		OnUnPress.Invoke();
		animator.SetBool("IsEnabled", false);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player_BottomTrigger"))
		{
			if (col.transform.parent.GetComponent<Rigidbody2D>().velocity.y < 0f)
			{
				Press();
			}

			string parentTag = col.transform.parent.tag;
			if (parentTag == "Player_Blue")
			{
				hasBlue = true;
			}
			else if (parentTag == "Player_Pink")
			{
				hasPink = true;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Player_BottomTrigger"))
		{
			string parentTag = col.transform.parent.tag;
			if (parentTag == "Player_Blue")
			{
				hasBlue = false;
			}
			else if (parentTag == "Player_Pink")
			{
				hasPink = false;
			}

			if (!hasBlue && !hasPink)
				UnPress();
		}
	}

}

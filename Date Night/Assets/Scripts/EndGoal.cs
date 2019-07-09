using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{

	public bool hasBlue;
	public bool hasPink;

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
		}
	}

	private void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag("Player_BottomTrigger"))
		{
			string parentTag = col.transform.parent.tag;
			if (parentTag == "Player_Blue")
			{
				hasBlue = true;
			} else if (parentTag == "Player_Pink")
			{
				hasPink = true;
			}
		}

		if (hasPink && hasBlue)
		{
			GameManager.instance.CompleteLevel();
		}
	}

}

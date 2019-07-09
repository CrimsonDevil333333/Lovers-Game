using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnd : MonoBehaviour
{
	public PlayerMovement movement;
	public GameObject heart;

	private bool hasEnded = false;

    // Update is called once per frame
    void Update()
    {
		if (GameManager.instance.levelComplete && !hasEnded)
		{
			hasEnded = true;
			movement.enabled = false;
			heart.SetActive(true);
		}
    }
}

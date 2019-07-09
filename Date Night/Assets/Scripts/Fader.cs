using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{

	public static Fader instance;

	private void Awake()
	{
		instance = this;
	}

	public Animator animator;

	public void FadeOut ()
	{
		animator.SetTrigger("FadeOut");
	}

	public void FadeIn()
	{
		StartCoroutine(FadeInCo());
	}

	IEnumerator FadeInCo()
	{
		animator.SetBool("FadeIn", true);

		yield return new WaitForSeconds(.6f);

		animator.SetBool("FadeIn", false);
	}

}

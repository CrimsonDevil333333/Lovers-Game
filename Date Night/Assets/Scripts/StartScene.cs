using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
	public float delay = 10f;

	private void Start()
	{
		StartCoroutine(Behaviour());
	}

	IEnumerator Behaviour()
    {
		yield return new WaitForSeconds(delay);

		Fader.instance.FadeOut();

		yield return new WaitForSeconds(.6f);

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;

	private void Awake()
	{
		instance = this;
	}

	public int currentLevel = 0;
	public int endLevel = 12;
	public bool levelComplete = false;
	public bool isReloading = false;

	private void Start()
	{
		if (SceneManager.sceneCount < 2)
			SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
	}

	public void RestartLevel()
	{
		if (isReloading)
			return;

		Debug.Log("It wasn't meant to be.");
		StartCoroutine(ReloadLevel());
	}

	IEnumerator ReloadLevel()
	{
		isReloading = true;

		AsyncOperation unload = SceneManager.UnloadSceneAsync(currentLevel);

		while (!unload.isDone)
		{
			yield return 0;
		}

		SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);

		Fader.instance.FadeIn();

		isReloading = false;
	}

	public void CompleteLevel()
	{
		if (levelComplete)
			return;

		levelComplete = true;
		Debug.Log("Love found a way!");

		StartCoroutine(LoadNextLevel());
	}

	IEnumerator LoadNextLevel()
	{
		yield return new WaitForSeconds(1f);

		Fader.instance.FadeOut();

		yield return new WaitForSeconds(0.6f);

		if (endLevel == currentLevel + 1)
		{
			SceneManager.LoadScene(currentLevel + 1, LoadSceneMode.Single);
		} else
		{
			AsyncOperation unload = SceneManager.UnloadSceneAsync(currentLevel);

			while (!unload.isDone)
			{
				yield return 0;
			}

			currentLevel++;
			SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
		}

		Fader.instance.FadeIn();

		levelComplete = false;
	}

}

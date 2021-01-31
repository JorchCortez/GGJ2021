using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class Typewritter : MonoBehaviour
{

	public TextMeshProUGUI txt;
	public string story;
	public Image fadePanel;
	public GameObject pressToContinue;

	void Awake()
	{ 
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine(PlayText());
	}

	private void Update()
	{
		if (pressToContinue.activeSelf)
		{ 
			if (Input.anyKey)
			{
				StartCoroutine(FadeToGame());
			}
		}
	}


	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(0.125f);

		}
		pressToContinue.SetActive(true);

	}


	IEnumerator FadeToGame()
	{ 
		Color color = fadePanel.color;
		while (color.a < 1.0f)
		{
			color.a += 2 * Time.deltaTime;
			fadePanel.color = color;
			yield return new WaitForEndOfFrame();
		}
		color.a = 1.0f;
		fadePanel.color = color;
		SceneManager.LoadScene("Game", LoadSceneMode.Single);
	}

}

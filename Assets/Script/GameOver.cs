using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public static bool GameOverFlag = false; 
	[SerializeField] GameObject text = null;

	void Start()
	{
		GameOverFlag = false;
	}

	void OnGUI()
	{
		if(GameOverFlag)
		{
			text.gameObject.SetActive(true);

			if(GUI.Button(new Rect(Screen.width / 4, Screen.height / 2, Screen.width / 2, 90), "Retry"))
			{
				GameOverFlag = false;
				SceneManager.LoadScene("main");
			}

		} else
		{
			text.gameObject.SetActive(false);
		}
	}
}
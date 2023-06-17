using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class MenuController : MonoBehaviour
{
	public static MenuController Instance { get; private set; }
	[SerializeField] private TextMeshProUGUI startButtonText;
	[SerializeField] private int transitionSceneIndex = 1;
	private int currentLevel = 0;
	private bool isNewGame = true;

	private void Awake() 
	{
		Debug.Log(PlayerPrefs.GetInt("skillPoints"));
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		int completedLevels = PlayerPrefs.GetInt("completedLevels");
		currentLevel = completedLevels + 1;
		if (completedLevels > 0)
		{
			startButtonText.text = "Продолжить";
			PlayerPrefs.SetInt("isNewGame",0);
		}
		else
		{
			startButtonText.text = "Новая игра";
			PlayerPrefs.SetInt("completedLevels", 0);
			PlayerPrefs.SetInt("isNewGame", 1);
		}

	}

	public void StartGame()
	{
		if (PlayerPrefs.GetInt("isNewGame") == 0)
		{
			PlayerPrefs.SetInt("levelToLoad", currentLevel  + 1);
		}
		else
		{
			PlayerPrefs.SetInt("levelToLoad", 2 + 1);
		}
		SceneManager.LoadScene(transitionSceneIndex);
	}
	public void StartGame(int level)
	{
		PlayerPrefs.SetInt("levelToLoad", level + 1);
		SceneManager.LoadScene(transitionSceneIndex);

	}
	public void ResetSaves()
	{
		PlayerPrefs.SetInt("isNewGame", 1);
		PlayerPrefs.SetInt("completedLevels", 0);
		PlayerPrefs.SetFloat("Volume", 0);
		PlayerPrefs.SetFloat("Sounds", 0);
		PlayerPrefs.SetFloat("Music", 0);
		PlayerPrefs.SetInt("speedLevel", 1);
		PlayerPrefs.SetInt("visionLevel", 1);
		PlayerPrefs.SetInt("skillPoints", 0);
		SceneManager.LoadScene(0);
	}
}

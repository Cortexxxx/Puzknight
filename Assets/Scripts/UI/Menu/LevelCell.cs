using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCell : MonoBehaviour
{
	public int levelIndex;
	[SerializeField] private GameObject lockWindow;
	public void RunLevel()
	{
		MenuController.Instance.StartGame(levelIndex);
	}
	private void Start()
	{
		if (PlayerPrefs.GetInt("completedLevels") + 2 >= levelIndex)
		{
			lockWindow.SetActive(false);


			GetComponent<Button>().onClick.RemoveAllListeners();
			GetComponent<Button>().onClick.AddListener(RunLevel);
		}
		else
		{
			lockWindow.SetActive(true);

		}

	}
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsGenerator : MonoBehaviour
{
	[SerializeField] GameObject levelCell;
	private void Awake()
	{
		Image[] children = GetComponentsInChildren<Image>();
		foreach (Image child in children)
		{
			Destroy(child.gameObject);
		}
		for (int i = 2; i < SceneManager.sceneCountInBuildSettings; i++)
		{
			GameObject cell = Instantiate(levelCell, transform);
			cell.GetComponentInChildren<TextMeshProUGUI>().text = (i - 1).ToString();
			cell.GetComponent<LevelCell>().levelIndex = i;
		}
	}
}

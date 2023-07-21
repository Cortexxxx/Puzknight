using UnityEngine;
using UnityEngine.SceneManagement;


public class Transition : MonoBehaviour
{
	private void Start()
	{
		SceneManager.LoadScene(PlayerPrefs.GetInt("levelToLoad"));
	}
}

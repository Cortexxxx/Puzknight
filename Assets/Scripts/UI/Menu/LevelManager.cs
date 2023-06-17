using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[HideInInspector] public static LevelManager Instance;
	private void Awake()
	{

		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	private void Update() {
		if (SceneManager.GetActiveScene().buildIndex == 0) {
            Destroy(gameObject);
        }
	}
	public IEnumerator RestartLevel()
	{
		yield return new WaitForSeconds(0.9f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

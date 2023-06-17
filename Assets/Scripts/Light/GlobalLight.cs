using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalLight : MonoBehaviour
{
	[HideInInspector] public static GlobalLight Instance;
	private void Update() {
		if (SceneManager.GetActiveScene().buildIndex == 0) {
            Destroy(gameObject);
        }
	}
    private void Awake() {
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
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContainer : MonoBehaviour
{
	private void Update() {
		if (SceneManager.GetActiveScene().buildIndex == 0) {
            Destroy(gameObject);
        }
	}
	public static UIContainer Instance;
	public GameObject signImage;
	public GameObject closeButton;
	public GameObject interactButton;
	public GameObject dropButton;
	public GameObject craftResultCell;
	public GameObject blackout1;
	public GameObject noticeInput;
	public GameObject workbenchImage;
	public GameObject craftCells;
	public GameObject bossHealthBar;
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
}

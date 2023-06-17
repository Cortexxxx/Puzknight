using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
	float per = 0;
	[HideInInspector] public bool isPlayerInArea = false;
	[SerializeField] private Image blackout;
	bool isDirectionX = false;
	private void Start()
	{
		blackout = UIContainer.Instance.blackout.GetComponent<Image>();
	}
	private void Update()
	{
		if (isPlayerInArea == true)
		{
			blackout.gameObject.SetActive(true);
			if (isDirectionX)
			{
				per = (Player.Instance.transform.position.x - GetComponentInParent<Finish>().startingPoint.x) / (transform.position.x - GetComponentInParent<Finish>().startingPoint.x);
				blackout.color = new Color(blackout.color.r, blackout.color.g, blackout.color.b, per);
			}
			else
			{
				per = (Player.Instance.transform.position.y - GetComponentInParent<Finish>().startingPoint.y) / (transform.position.y - GetComponentInParent<Finish>().startingPoint.y);
				blackout.color = new Color(blackout.color.r, blackout.color.g, blackout.color.b, per);
			}
		}
		else if (blackout.color.a != 0)
		{
			blackout.color = new Color(blackout.color.r, blackout.color.g, blackout.color.b, 0);
			blackout.gameObject.SetActive(false);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() != null)
		{
			PlayerPrefs.SetInt("completedLevels", PlayerPrefs.GetInt("completedLevels") + 1);
			PlayerPrefs.SetInt("isNewGame", 0);
			PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") + 1);
			if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
			else
			{
				SceneManager.LoadScene(0);
			}
		}
	}

}

using UnityEngine;
using UnityEngine.UI;

public class FinishPoint : MonoBehaviour
{
	float per = 0;
	[HideInInspector] public bool isPlayerInArea = false;
	[SerializeField] private Image blackout;
	bool isDirectionX = false;
	private void Update()
	{
		if (isPlayerInArea == true)
		{
			blackout.gameObject.SetActive(true);
			if (isDirectionX)
			{
				per = (Player.instance.transform.position.x - GetComponentInParent<Finish>().startingPoint.x) / (transform.position.x - GetComponentInParent<Finish>().startingPoint.x);
				blackout.color = new Color(blackout.color.r, blackout.color.g, blackout.color.b, per);
			}
			else
			{
				per = (Player.instance.transform.position.y - GetComponentInParent<Finish>().startingPoint.y) / (transform.position.y - GetComponentInParent<Finish>().startingPoint.y);
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
			Debug.Log("Finish");
		}
	}

}
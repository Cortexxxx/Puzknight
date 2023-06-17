using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
	public static InteractButton instance;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			gameObject.SetActive(false);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}

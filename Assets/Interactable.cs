using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
	[SerializeField] protected GameObject outline;
	protected Vector3 delta;
	protected bool isActive;
	protected bool canBlock = false;
	protected bool canOpen = false;
	protected bool canClose = false;

	protected virtual void Update()
	{
		delta = Player.instance.transform.position - transform.position;
		if (Mathf.Abs(delta.x) < 1 && Mathf.Abs(delta.y) < 1)
		{
			canBlock = true;
			canOpen = true;
			if (Player.instance.interactingWith == null && !outline.activeInHierarchy)
			{
				Player.instance.interactingWith = this;
				outline.SetActive(true);

				if (InteractButton.instance != null)
				{
					Debug.Log(1);

					InteractButton.instance.GetComponent<Button>().onClick.RemoveAllListeners();
					Debug.Log(1);
					InteractButton.instance.GetComponent<Button>().onClick.AddListener(Use);
				}
			}																	
			else if (Player.instance.interactingWith != null)
			{
				if (Mathf.Sqrt((Mathf.Pow(Player.instance.interactingWith.delta.x, 2) + Mathf.Pow(Player.instance.interactingWith.delta.y, 2))) > Mathf.Sqrt(Mathf.Pow(delta.x, 2) * Mathf.Pow(delta.y, 2)))
				{
					Player.instance.interactingWith = this;										
				}
			}
		}
		else if (canBlock)
		{
			canClose = true;	
			canBlock = false;
			outline.SetActive(false);
			Player.instance.interactingWith = null; 
		}
	}
	protected virtual void Use()
	{
		Debug.Log(1);

	}
}


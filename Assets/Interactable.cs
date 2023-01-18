using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
	[SerializeField] protected GameObject outline;
	protected Vector3 delta;
	protected bool isActive = true;
	protected bool canBlock = false;
	protected bool canOpen = false;
	protected bool canClose = false;
	[SerializeField] protected Button interactButton;
	[SerializeField] protected string interactButtonText;

	protected virtual void Update()
	{
		delta = Player.instance.transform.position - transform.position;
		if (Mathf.Abs(delta.x) < 1 && Mathf.Abs(delta.y) < 1)
		{
			canBlock = true;
			canOpen = true;
			if (Player.instance.interactingWith == null && !outline.activeInHierarchy && isActive)
			{
				Player.instance.interactingWith = this;
				outline.SetActive(true);

				if (InteractButton.instance != null)
				{
					InteractButton.instance.GetComponent<Button>().onClick.RemoveAllListeners();
					InteractButton.instance.GetComponent<Button>().onClick.AddListener(Use);
					DisplayInteractButton();
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
	protected void DisplayInteractButton()
	{
		interactButton.gameObject.SetActive(true);
		interactButton.GetComponentInChildren<TextMeshProUGUI>().text = interactButtonText;
	}
}


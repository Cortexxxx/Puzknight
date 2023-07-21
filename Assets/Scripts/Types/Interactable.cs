using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
	[SerializeField] protected GameObject outline;
	[SerializeField] protected string interactButtonText;
	[HideInInspector] public bool isActive = true;
	protected float delta;
	protected Button interactButton;
	protected bool canDisableInteracting = false;
	protected bool canDisplayInteractButton = false;
	protected bool canHideInteractButton = false;
	protected bool wasDroppedInRange = false;

	private void Start()
	{
		interactButton = UIContainer.Instance.interactButton.GetComponent<Button>();
	}
	protected virtual void Update()
	{
		if (interactButton == null) {
			interactButton = UIContainer.Instance.interactButton.GetComponent<Button>();
		}
		delta = Vector3.Distance(Player.Instance.transform.position, transform.position);
		// If Player In Range, show interact button
		if (delta < 0.7)
		{
			canDisableInteracting = true;
			canDisplayInteractButton = true;
			if (Player.Instance.interactingWith == null && !outline.activeInHierarchy && isActive)
			{
				Player.Instance.interactingWith = this;
				outline.SetActive(true);
				if (InteractButton.instance != null)
				{
					interactButton.GetComponent<Button>().onClick.RemoveAllListeners();
					interactButton.GetComponent<Button>().onClick.AddListener(UIContainer.Instance.GetComponent<AudioSource>().Play);
					interactButton.GetComponent<Button>().onClick.AddListener(Use);
					DisplayInteractButton();
				}
			}																	
			else if (Player.Instance.interactingWith != null)
			{
				if (Player.Instance.interactingWith.delta > delta)
				{
					Player.Instance.interactingWith = this;										
				}
			}
		}
		else if (canDisableInteracting)
		{
			DisableInteracting();
		}
		if (canDisplayInteractButton)
		{
			canDisplayInteractButton = false;
			if (outline.activeInHierarchy && !interactButton.gameObject.activeInHierarchy)
			{
				DisplayInteractButton();
			}
		}
		else if (canHideInteractButton && !outline.activeInHierarchy && interactButton.gameObject.activeInHierarchy)
		{
			canHideInteractButton = false;
			interactButton.gameObject.SetActive(false);
		}
	}
	protected virtual void Use()
	{
	}
	protected virtual void DisplayInteractButton()
	{
		interactButton.gameObject.SetActive(true);
		interactButton.GetComponentInChildren<TextMeshProUGUI>().text = interactButtonText;
	}
	protected virtual void DisableInteracting()
	{
		if (interactButton == null)
		{
			interactButton = UIContainer.Instance.interactButton.GetComponent<Button>();
		}
		canHideInteractButton = true;
		canDisableInteracting = false;
		if (outline != null)
		{
			outline.SetActive(false);
		}
		Player.Instance.interactingWith = null;
		interactButton.gameObject.SetActive(false);
	}
}


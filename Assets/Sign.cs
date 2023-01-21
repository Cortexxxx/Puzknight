using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : Interactable
{
	[SerializeField] private GameObject noticeImage;
	[SerializeField] string text;
	private bool isAlreadyUsed;
	protected override void Update()
	{

		base.Update();
		if (canOpen)
		{
			canOpen = false;
			if (outline.activeInHierarchy && !interactButton.gameObject.activeInHierarchy && !isAlreadyUsed)
			{
				DisplayInteractButton();
			}
		}
		else if (canClose && !outline.activeInHierarchy && interactButton.gameObject.activeInHierarchy)
		{
			canClose = false;
			interactButton.gameObject.SetActive(false);
		}

	}
	protected override void Use()
	{
		base.Use();
		if (!noticeImage.activeInHierarchy)
		{
			Open();
		}
	}
	protected void Open()
	{
		noticeImage.SetActive(true);
		Player.instance.enabled = false;
		noticeImage.GetComponentInChildren<TextMeshProUGUI>().text = text;
		UIContainer.Instance.closeButton.GetComponent<Button>().onClick.RemoveAllListeners();
		UIContainer.Instance.closeButton.GetComponent<Button>().onClick.AddListener(Close);
		isAlreadyUsed = true;
		UIContainer.Instance.interactButton.SetActive(false);
	}
	protected void Close()
	{
		isAlreadyUsed = false;
		noticeImage.SetActive(false);
		Player.instance.enabled = true;
		UIContainer.Instance.interactButton.SetActive(true);

	}
}

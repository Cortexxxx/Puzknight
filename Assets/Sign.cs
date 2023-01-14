using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : Interactable
{
	[SerializeField] protected Button button;
	[SerializeField] private GameObject noticeImage;
	[SerializeField] string text;
	private bool isAlreadyUsed;
	protected override void Update()
	{

		base.Update();
		if (canOpen)
		{
			canOpen = false;
			if (outline.activeInHierarchy && !button.gameObject.activeInHierarchy && !isAlreadyUsed)
			{
				button.gameObject.SetActive(true);
				button.GetComponentInChildren<TextMeshProUGUI>().text = "READ";
			}

		}
		else if (canClose && !outline.activeInHierarchy && button.gameObject.activeInHierarchy)
		{
			canClose = false;
			button.gameObject.SetActive(false);
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
		Debug.Log(2);

		UIContainer.Instance.signButton.SetActive(false);
	}
	protected void Close()
	{
		Debug.Log(1);
		isAlreadyUsed = false;
		noticeImage.SetActive(false);
		Player.instance.enabled = true;
		UIContainer.Instance.signButton.SetActive(true);

	}
}

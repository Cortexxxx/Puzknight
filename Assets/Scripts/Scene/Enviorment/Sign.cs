using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : Interactable
{
	[SerializeField] private GameObject noticeImage;
	[SerializeField] string text;

	protected void Start()
	{
		noticeImage = UIContainer.Instance.signImage;
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
		Player.Instance.GetComponent<PlayerMovement>().enabled = false;
		noticeImage.GetComponentInChildren<TextMeshProUGUI>().text = text;
        UIContainer.Instance.closeButton.SetActive(true);
        UIContainer.Instance.closeButton.GetComponent<Button>().onClick.RemoveAllListeners();
        UIContainer.Instance.closeButton.GetComponent<Button>().onClick.AddListener(UIContainer.Instance.GetComponent<AudioSource>().Play);
        UIContainer.Instance.closeButton.GetComponent<Button>().onClick.AddListener(Close);
		UIContainer.Instance.interactButton.SetActive(false);
	}
	protected void Close()
	{
		noticeImage.SetActive(false);
        UIContainer.Instance.closeButton.SetActive(false);
        Player.Instance.GetComponent<PlayerMovement>().enabled = true;
		UIContainer.Instance.interactButton.SetActive(true);

	}
}

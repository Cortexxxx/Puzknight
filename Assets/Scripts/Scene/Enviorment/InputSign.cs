using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputSign : Interactable
{
	private NoticeInput noticeInput;
	[SerializeField] string text;
	[SerializeField] string answer;
	[SerializeField] GameObject Object;

	protected void Start()
	{
		noticeInput = UIContainer.Instance.noticeInput.GetComponent<NoticeInput>();
	}

	protected override void Use()
	{
		base.Use();
		if (!noticeInput.gameObject.activeInHierarchy)
		{
			Open();
		}
	}
	protected void Open()
	{
		Button closeButton = UIContainer.Instance.closeButton.GetComponent<Button>();
		noticeInput.gameObject.SetActive(true);
		Player.Instance.GetComponent<PlayerMovement>().enabled = false;
		noticeInput.GetComponent<NoticeInput>().text.text = text;
		closeButton.gameObject.SetActive(true);
		closeButton.onClick.RemoveAllListeners();
		closeButton.onClick.AddListener(Close);
		UIContainer.Instance.interactButton.SetActive(false);
		noticeInput.button.onClick.RemoveAllListeners();
		noticeInput.button.onClick.AddListener(CheckAnswer);
	}
	protected void Close()
	{
		noticeInput.gameObject.SetActive(false);
		UIContainer.Instance.closeButton.SetActive(false);
		Player.Instance.GetComponent<PlayerMovement>().enabled = true;
		UIContainer.Instance.interactButton.SetActive(true);

	}
	public void CheckAnswer()
	{
		if (UIContainer.Instance.noticeInput.GetComponent<NoticeInput>().inputField.text.ToLower().Replace(" ", "") == answer.ToLower().Replace(" ", ""))
		{
			// Correct answer
			Object.GetComponent<Activatable>().Activate();
			Close();
		}
		else
		{
			// Incorrect answer
		}
	}
}

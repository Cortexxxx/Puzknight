using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NoticeInput : MonoBehaviour
{
	public TextMeshProUGUI text;
	public Button button;
	public TMP_InputField inputField;

	public void CheckAnswer(string answer)
	{
		if (inputField.text.ToLower().Replace(" ", "") == answer.ToLower().Replace(" ", ""))
		{
			Debug.Log("Correct!");
		}
		else
		{
			Debug.Log("Incorrect!");
		}
	}
}

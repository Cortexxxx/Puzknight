using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
	[SerializeField] private GameObject lines;
	[SerializeField] private GameObject line;
	public void GenerateLines(int count)
	{
		ClearLines(); 
		for (int i = 0; i < count; i++)
		{
			Instantiate(line, lines.transform);
		}
	}
	private void ClearLines()
	{
		for (int i = 1; i < lines.GetComponentsInChildren<Image>().Length; i++)
		{
			Destroy(lines.GetComponentsInChildren<Image>()[i].gameObject);
		}
	}
}

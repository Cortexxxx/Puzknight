using UnityEngine;
using UnityEngine.UI;

public class CraftResultButton : MonoBehaviour
{
	private CraftResultCell craftCell;
	private Image image;
	[SerializeField] private CraftCell[] craftCells;
	private void OnEnable()
	{
		craftCell = UIContainer.Instance.craftResultCell.GetComponent<CraftResultCell>();
		image = craftCell.cellImage.GetComponent<Image>();
	}

	public void Take()
	{
		UIContainer.Instance.GetComponent<AudioSource>().Play();
		image.sprite = null;
		image.color = new Color(255, 255, 255, 0);
		Player.Instance.holdingItem = craftCell.item;
		Player.Instance.holdingItem.gameObject.transform.SetParent(Player.Instance.transform);
		Player.Instance.holdingItem.gameObject.transform.localPosition = new Vector2(0, 1);
		Player.Instance.holdingItem.gameObject.transform.localScale = new Vector2(0.65f, 0.65f);
		craftCell.item = null;
		foreach (var cell in craftCells)
		{
			cell.item = null;
			cell.cellImage.GetComponent<Image>().sprite = null;
			cell.cellImage.GetComponent<Image>().color = new Color(255, 255, 255, 0);
			cell.Refresh();
		}
		craftCell.workbench.itemObject = null;
	}
}

using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CellButton : MonoBehaviour
{
    private CraftCell craftCell;
    private Image image;
    private Pickupable holdingItem;
	private void OnEnable()
	{
        craftCell = GetComponentInParent<CraftCell>();
        image = craftCell.cellImage.GetComponent<Image>();
        holdingItem = Player.Instance.holdingItem;
	}
	public void Put()
    {
		craftCell.item = holdingItem;
		Sprite sprite = Resources.LoadAll<SpriteRenderer>("Prefabs\\Items").Where(x => x.GetComponent<Pickupable>().itemSO.name == holdingItem.itemSO.name).ToArray()[0].sprite;
        image.sprite = sprite;
        image.color = new Color(255,255,255,255);
		holdingItem.gameObject.transform.SetParent(craftCell.transform);
		holdingItem.gameObject.transform.position = new Vector2(100 ^ 50, 0);
		Player.Instance.holdingItem = null;
		craftCell.Refresh();
        CraftCell[] craftCells = craftCell.GetComponentInParent<HorizontalLayoutGroup>().GetComponentsInChildren<CraftCell>();
        foreach (var cell in craftCells)
        {
            cell.Refresh();
        }
	}

    public void Take()
    {
        image.sprite = null;
		image.color = new Color(255, 255, 255, 0);
		Player.Instance.holdingItem = craftCell.item;
		Player.Instance.holdingItem.gameObject.transform.SetParent(Player.Instance.transform);
		Player.Instance.holdingItem.gameObject.transform.localPosition = new Vector2(0, 1);
		craftCell.item = null;
		craftCell.Refresh();
		CraftCell[] craftCells = craftCell.GetComponentInParent<HorizontalLayoutGroup>().GetComponentsInChildren<CraftCell>();
		foreach (var cell in craftCells)
		{
			cell.Refresh();
		}
	}
}

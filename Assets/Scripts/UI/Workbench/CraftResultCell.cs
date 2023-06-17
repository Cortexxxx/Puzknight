using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CraftResultCell : MonoBehaviour
{

	[SerializeField] private Button cellButton;
	public Image cellImage;
	public Pickupable item;
	public Workbench workbench;
	private void OnEnable()
	{
		Refresh();
	}

	public void Refresh()
	{
		if (item != null)
		{
			Pickupable pickupable = Resources.LoadAll<Pickupable>("Prefabs\\Items").Where(x => x.itemSO.name.ToLower() == item.itemSO.name.ToLower()).ToArray()[0];
		}
		cellButton.gameObject.SetActive(false);
		if (item != null && Player.Instance.holdingItem == null)
		{
			cellButton.gameObject.SetActive(true);
			cellButton.onClick.RemoveAllListeners();
			cellButton.onClick.AddListener(cellButton.GetComponent<CraftResultButton>().Take);
			cellButton.GetComponentInChildren<TextMeshProUGUI>().text = "Взять";
			Sprite sprite = Resources.LoadAll<SpriteRenderer>("Prefabs\\Items").Where(x => x.GetComponent<Pickupable>().itemSO.name == item.itemSO.name).ToArray()[0].sprite;
			cellImage.GetComponent<Image>().sprite = sprite;
			cellImage.GetComponent<Image>().color = new Color(255, 255, 255, 255);

		}
	}
}

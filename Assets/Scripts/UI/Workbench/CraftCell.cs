using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CraftCell : MonoBehaviour
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
		if (item == null)
		{

		}
		if (item == null && Player.Instance.holdingItem != null)
        {
            cellButton.gameObject.SetActive(true);
            cellButton.onClick.RemoveAllListeners();
            cellButton.onClick.AddListener(cellButton.GetComponent<CellButton>().Put);
            cellButton.GetComponentInChildren<TextMeshProUGUI>().text = "��������";
        }
        
        else if (item != null && Player.Instance.holdingItem == null)
        {
			cellButton.gameObject.SetActive(true);
			cellButton.onClick.RemoveAllListeners();
			cellButton.onClick.AddListener(cellButton.GetComponent<CellButton>().Take);
			cellButton.GetComponentInChildren<TextMeshProUGUI>().text = "�����";
        }
		cellButton.onClick.AddListener(UIContainer.Instance.GetComponent<AudioSource>().Play);
		workbench.Craft();
	}
}

using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System;

public class Workbench : Interactable
{
	[SerializeField] private GameObject workbenchImage;
	[SerializeField] private GameObject craftCellsObject;
	public GameObject itemObject;

	protected override void Use()
	{
		base.Use();
		if (!workbenchImage.activeInHierarchy)
		{
			Open();
		}
	}
	private void Start() {
		workbenchImage = UIContainer.Instance.workbenchImage;
		craftCellsObject = UIContainer.Instance.craftCells;
	}
	protected void Open()
	{
		CraftCell[] craftCells = craftCellsObject.GetComponentsInChildren<CraftCell>();
		for (int i = 0; i < craftCells.Length; i++)
		{
			craftCells[i].workbench = this;
		}
		UIContainer.Instance.craftResultCell.GetComponent<CraftResultCell>().workbench = this;
		workbenchImage.SetActive(true);
		Player.Instance.GetComponent<PlayerMovement>().enabled = false;
		UIContainer.Instance.closeButton.SetActive(true);
		UIContainer.Instance.closeButton.GetComponent<Button>().onClick.RemoveAllListeners();
		UIContainer.Instance.closeButton.GetComponent<Button>().onClick.AddListener(UIContainer.Instance.GetComponent<AudioSource>().Play);


		UIContainer.Instance.closeButton.GetComponent<Button>().onClick.AddListener(Close);

		UIContainer.Instance.interactButton.SetActive(false);

	}
	protected void Close()
	{
		workbenchImage.SetActive(false);
		Player.Instance.GetComponent<PlayerMovement>().enabled = true;
		UIContainer.Instance.closeButton.SetActive(false);
		UIContainer.Instance.interactButton.SetActive(true);

	}

	public void Craft()
	{
		string[] workBenchItemNames = new string[4];
		RecipeSO[] recipes = Resources.LoadAll<RecipeSO>("Recipes\\").ToArray();
		CraftCell[] craftCells = craftCellsObject.GetComponentsInChildren<CraftCell>();
		for (int i = 0; i < craftCells.Length; i++)
		{
			workBenchItemNames[i] = craftCells[i]?.item?.itemSO?.Name;
		}

		foreach (var item in recipes)
		{
			string[] recipeNames = new string[4];
			for (int i = 0; i < 4; i++)
			{
				recipeNames[i] = item?.items[i]?.Name;
			}
			Array.Sort(recipeNames);
			Array.Sort(workBenchItemNames);
			int counter = 0;
			for (int i = 0; i < 4; i++)
			{
				if (recipeNames[i] == workBenchItemNames[i])
				{
					counter++;
				}
			}

			if (counter == 4 && itemObject == null)
			{

				itemObject = Instantiate(item.item.prefab, new Vector2(100 ^ 50, 0), Quaternion.identity, UIContainer.Instance.craftResultCell.transform);
				UIContainer.Instance.craftResultCell.GetComponent<CraftResultCell>().item = itemObject.GetComponent<Pickupable>();
			}
			UIContainer.Instance.craftResultCell.GetComponent<CraftResultCell>().Refresh();

		}
	}
}

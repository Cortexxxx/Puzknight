using UnityEngine;

public class Pickupable : Interactable
{

	public ItemSO itemSO;
	protected override void Use()
	{

		base.Use();
		if (transform?.parent?.GetComponent<BalancePart>() != null)
		{
			transform.parent.GetComponent<BalancePart>().item = null;
		}
		gameObject.transform.parent = null;
		transform.localScale = new Vector2(1, 1);

		gameObject.transform.parent = Player.Instance.transform;
		GetComponent<SpriteRenderer>().sortingLayerName = "PropsUponPlayer";
		transform.localPosition = new Vector2(0, 1);
		Player.Instance.holdingItem = this;
		isActive = false;
	}
	protected override void Update()
	{
		base.Update();
	}
	protected override void DisplayInteractButton()
	{
		if (Player.Instance.holdingItem != null)
		{
			return;
		}
		base.DisplayInteractButton();
	}
	private void Start()
	{
		interactButtonText = "Взять";
	}
}

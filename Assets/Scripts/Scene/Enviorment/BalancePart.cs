using UnityEngine;

/*
 Не работает положение предмета на весы. Игрок берёт предмет а весы это не учитывают
 */
public class BalancePart : Interactable
{
	[SerializeField] public Pickupable item;
	protected override void Use()
	{
		item = Player.Instance.holdingItem;
		UIContainer.Instance.dropButton.GetComponent<DropButton>().Drop();
		item.gameObject.transform.parent = null;
		item.gameObject.transform.localScale = new Vector2(.7f, .7f);

		item.gameObject.transform.parent = gameObject.transform;
		item.gameObject.transform.position = gameObject.transform.position;
		UIContainer.Instance.dropButton.SetActive(false);
		Vector2 pos = Player.Instance.transform.position;
		Player.Instance.transform.position = new Vector2(100, 0);
		Player.Instance.transform.position = pos;
		canHideInteractButton = true;
		DisableInteracting();
		GetComponentInParent<Balance>().ReCount();
	}
	protected override void Update()
	{
		if (Player.Instance.holdingItem != null && item == null)
		{
			isActive = true;

			base.Update();
		}
		else
		{
			isActive = false;
			outline.SetActive(false);
		}
	}
}

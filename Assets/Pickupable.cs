using UnityEngine;

public class Pickupable : Interactable
{
	protected override void Use()
	{
		base.Use();
		gameObject.transform.parent = Player.instance.transform;
		transform.localPosition = new Vector2(0, 1);
		Player.instance.holdingItem = this;
		isActive = false;
	}
}

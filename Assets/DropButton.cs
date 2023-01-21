using UnityEngine;

public class DropButton : MonoBehaviour
{
	public void Drop()
	{
		Pickupable item = Player.instance.GetComponentInChildren<Pickupable>();
		item.isActive = true;
		item.transform.localPosition = Vector3.zero;
		item.transform.parent = Enviorment.instance.transform;
		item.transform.position = Player.instance.transform.position;
		Player.instance.holdingItem = null;
		gameObject.SetActive(false);
	}
}

using UnityEngine;

public class DropButton : MonoBehaviour
{
	public void Drop()
	{
		Pickupable item = Player.Instance.GetComponentInChildren<Pickupable>();
		item.isActive = true;
		item.transform.localPosition = Vector3.zero;
		item.transform.parent = Enviorment.instance.transform;
		item.transform.position = Player.Instance.transform.position;
		item.GetComponent<SpriteRenderer>().sortingLayerName = "PropsUnderPlayer";
		Player.Instance.holdingItem = null;
		gameObject.SetActive(false);
	}
}

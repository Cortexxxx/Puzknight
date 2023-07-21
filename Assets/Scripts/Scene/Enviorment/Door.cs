using UnityEngine;

public class Door : Activatable
{
	private Animator animator;
	private BoxCollider2D boxCollider2D;
	public DoorType doorType;

	public enum DoorType
	{
		Key,
		Plate,
		Other
	}

	protected override void Update()
	{
		if (doorType == DoorType.Key)
		{
			if (Player.Instance.holdingItem?.itemSO?.Name.ToLower() == "key")
			{
				base.Update();
			}
			else if (Player.Instance.holdingItem?.itemSO?.Name.ToLower() != "key" && outline.activeInHierarchy)
			{
				DisableInteracting();
			}
		}
	}

	private void Start()
	{
		animator = GetComponent<Animator>();
		boxCollider2D = GetComponent<BoxCollider2D>();
	}
	public override void Activate()
	{
		Use();
	}
	protected override void Use()
	{
		base.Use();
		DisableInteracting();
		Destroy(Player.Instance?.holdingItem?.gameObject);
		GetComponent<AudioSource>().Play();
		Player.Instance.holdingItem = null;
		GetComponent<Animator>().SetTrigger("Toggle");
		Destroy(GetComponent<Collider2D>());
		Destroy(this);
	}
}

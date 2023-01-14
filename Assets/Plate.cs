using UnityEngine;

public class Plate : Collidable
{
	[SerializeField] protected Door toggleObject;
	protected bool active = true;
	protected override void OnCollide(Collider2D collider2D)
	{
		base.OnCollide(collider2D);
		if (true)
		{
			if (collider2D.GetComponent<Player>() != null && active)
			{
				toggleObject.GetComponent<Door>().Toggle();
				GetComponent<Animator>().SetBool("Pressed", true);
				active = false;
			}
		}
	}
}

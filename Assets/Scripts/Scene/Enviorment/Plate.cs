using UnityEngine;

public class Plate : Collidable
{
	protected bool active = true;
	protected override void OnCollide(Collider2D collider2D)
	{
		base.OnCollide(collider2D);
		if (collider2D.GetComponent<Player>() != null && active)
		{
			Use(collider2D);
		}
	}
	
	protected virtual void Use(Collider2D collider2D)
	{
	}
}

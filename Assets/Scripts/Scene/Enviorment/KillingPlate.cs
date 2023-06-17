using UnityEngine;

public class KillingPlate : Plate
{
	protected override void Use(Collider2D collider2D)
	{
		base.Use(collider2D);
		Player.Instance.Kill();
		active = false;
	}
}

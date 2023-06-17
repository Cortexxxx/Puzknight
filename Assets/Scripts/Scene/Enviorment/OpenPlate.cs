using UnityEngine;

public class OpenPlate : Plate
{
	[SerializeField] protected Door toggleObject2;
	protected override void Use(Collider2D collider2D)
	{
		base.Use(collider2D);
		GetComponent<Animator>().SetBool("Pressed", true);
		active = false;
		toggleObject2.Activate();
	}
}

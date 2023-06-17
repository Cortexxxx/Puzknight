using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonationPlate : Plate
{
	[SerializeField] private Dynamite[] dynamites;
	protected override void Use(Collider2D collider2D)
	{
		base.Use(collider2D);
		for (int i = 0; i < dynamites.Length; i++)
		{
			dynamites[i].Detonate();
		}
	}
}

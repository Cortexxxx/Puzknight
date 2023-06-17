using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : Interactable
{
	protected override void Use()
	{
		if (transform.rotation.eulerAngles.z == 270)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
		}
	}
}

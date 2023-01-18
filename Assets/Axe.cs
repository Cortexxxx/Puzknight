using UnityEngine;

public class Axe : Pickupable
{

	protected override void Update()
	{
		base.Update();
		if (canOpen)
		{
			canOpen = false;
			if (outline.activeInHierarchy && !interactButton.gameObject.activeInHierarchy)
			{
				DisplayInteractButton();
			}
		}
		else if (canClose && !outline.activeInHierarchy && interactButton.gameObject.activeInHierarchy)
		{
			canClose = false;
			interactButton.gameObject.SetActive(false);
		}

	}
}


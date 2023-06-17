using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoner : Boss
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.GetComponent<Dynamite>() != null)
		{
			Health -= 1;
			collision.collider.GetComponent<Dynamite>().Detonate();
		}
		if (collision.collider.GetComponent<Player>() != null)
		{
			Player.Instance.Kill();
		}
	}
}

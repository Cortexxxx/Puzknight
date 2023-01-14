using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
	[HideInInspector] public Vector3 startingPoint;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() != null)
		{
			startingPoint = transform.position;
			GetComponentInChildren<FinishPoint>().isPlayerInArea = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() != null)
		{
			GetComponentInChildren<FinishPoint>().isPlayerInArea = false;
		}
	}
}

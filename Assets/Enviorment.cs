using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviorment : MonoBehaviour
{
	[HideInInspector] public static Enviorment instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
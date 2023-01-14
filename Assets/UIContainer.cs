using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContainer : MonoBehaviour
{
	public static UIContainer Instance;
	public GameObject signImage;
	public GameObject closeButton;
	public GameObject signButton;
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
			DontDestroyOnLoad(signImage);
			DontDestroyOnLoad(closeButton);
			DontDestroyOnLoad(signButton);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}

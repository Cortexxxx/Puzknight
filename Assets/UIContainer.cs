using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContainer : MonoBehaviour
{
	public static UIContainer Instance;
	public GameObject signImage;
	public GameObject closeButton;
	public GameObject interactButton;
	public GameObject dropButton;
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
			DontDestroyOnLoad(signImage);
			DontDestroyOnLoad(closeButton);
			DontDestroyOnLoad(interactButton);
			DontDestroyOnLoad(dropButton);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}

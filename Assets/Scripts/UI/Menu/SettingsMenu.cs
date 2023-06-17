using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
	private void Awake()
	{
		Settings.Instance.SetSettingsMenu();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
	private bool isAlreadyAssembled = false;
	[SerializeField] private float rot;
	[SerializeField] private Door door;
	private void RandomiseFrames()
	{
		SpriteRenderer[] frames = GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer frame in frames)
		{
			frame.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 3) * 90);
		}
	}
	private void Start()
	{
		RandomiseFrames();
	}
	private void Update()
	{
		if (!isAlreadyAssembled)
		{
			SpriteRenderer[] frames = GetComponentsInChildren<SpriteRenderer>();
			bool isReady = true;
			foreach (SpriteRenderer frame in frames)
			{
				Debug.Log(frame.transform.rotation.z);

				if (frame.transform.rotation.z != 0)
				{
					isReady = false;
					break;
				}
			}
			if (isReady)
			{
				door.Activate();
				isAlreadyAssembled = true;
			}
		}

	}
}

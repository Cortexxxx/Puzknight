using UnityEngine;

public class Enviorment : MonoBehaviour
{
	[HideInInspector] public static Enviorment instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}

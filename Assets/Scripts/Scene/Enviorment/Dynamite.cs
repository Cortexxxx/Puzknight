using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
	[SerializeField] private GameObject explotion;
	public void Detonate()
	{
		Debug.Log("KABOOM!");
		explotion.SetActive(true);
		explotion.transform.parent = null;
		explotion.GetComponent<Animator>().SetTrigger("Explode");
		Destroy(gameObject);
		Destroy(explotion, 1f);
	}
}

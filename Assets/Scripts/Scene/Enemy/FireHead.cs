using UnityEngine;

public class FireHead : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() != null)
		{
			Transform child = GetComponentsInChildren<Transform>()[1];
			child.GetComponent<AudioSource>().Play();
			child.GetComponent<Animator>().SetTrigger("Explode");
			Player.Instance.Kill();
			GetComponent<EnemyPatrol>().enabled = false;
			gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
			Destroy(gameObject, 1);
		}
	}
}

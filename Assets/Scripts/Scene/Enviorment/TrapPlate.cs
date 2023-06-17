using UnityEngine;
using System.Collections;

public class TrapPlate : Plate
{
	[SerializeField] private bool isTrap = true;
	[SerializeField] private GameObject arrow;
	[SerializeField] private Transform arrowSpawnPoint;
	private bool isActivated = false;
	protected override void Use(Collider2D collider2D)
	{
		
		base.Use(collider2D);
		if (!isActivated)
		{
			isActivated = true;
			GetComponent<AudioSource>().Play();
			if (isTrap) {
				Player.Instance.GetComponent<PlayerMovement>().enabled = false;
				Player.Instance.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
				StartCoroutine(LaunchArrows());
			}

		}



	}
	IEnumerator LaunchArrows()
	{
		Instantiate(arrow, new Vector2(arrowSpawnPoint.position.x, arrowSpawnPoint.position.y + 0.3f), Quaternion.identity, gameObject.transform);
		yield return new WaitForSeconds(0.1f);
		Instantiate(arrow, new Vector2(arrowSpawnPoint.position.x, arrowSpawnPoint.position.y - 0.3f), Quaternion.identity, gameObject.transform);
		yield return new WaitForSeconds(0.1f);
		Instantiate(arrow, new Vector2(arrowSpawnPoint.position.x, arrowSpawnPoint.position.y), Quaternion.identity, gameObject.transform);
	}
}

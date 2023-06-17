using UnityEngine;

public class BossTrigger : MonoBehaviour
{
	[SerializeField] private Stoner stoner;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Active");
		stoner.GetComponent<EnemyFollow>().enabled = true;
	}
}

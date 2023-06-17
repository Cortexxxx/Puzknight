using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
	[SerializeField] private ContactFilter2D contactFilter;
	private BoxCollider2D boxCollider2D;
	private Collider2D[] hits = new Collider2D[10];

	protected virtual void Start()
	{
		boxCollider2D = GetComponent<BoxCollider2D>();
	}

	protected virtual void Update()
	{
		boxCollider2D.OverlapCollider(contactFilter, hits);
		for (int i = 0; i < hits.Length; i++)
		{
			if (hits[i] == null)
			{
				continue;
			}
			OnCollide(hits[i]);
			hits[i] = null;
		}
	}
	protected virtual void OnCollide(Collider2D collider2D)
	{

	}
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	[SerializeField] private Transform path;
	[SerializeField] private float speed = 5f;
	[SerializeField] private bool cycled = false;
	private List<Transform> points;
	private Rigidbody2D rb;
	private Player player;
	private bool reverse = false;
	int currentPoint = 1;
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		currentPoint = 1;
		points = path.GetComponentsInChildren<Transform>().ToList();
		points.RemoveRange(0,1);
		transform.position = points[0].transform.position;
	}
	private void FixedUpdate()
	{
		float distance = Vector2.Distance(rb.position, points[currentPoint].position);

		if (distance < 0.1f)
		{
			if (reverse)
			{
				currentPoint--;
			}
			else
			{
				currentPoint++;
			}
		}
		if (currentPoint >= points.Count)
		{
			if (cycled)
			{
				currentPoint = 0;
				reverse = false;
			}
			currentPoint--;
			reverse = true;
		}
		if (currentPoint < 0)
		{
			currentPoint++;
			reverse = false;
		}
		Vector2 direction = (Vector2)points[currentPoint].position - rb.position;
		direction.Normalize();
		rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
		

	}
}

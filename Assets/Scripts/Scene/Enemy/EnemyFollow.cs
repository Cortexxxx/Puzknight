using UnityEngine;
using UnityEngine.UIElements;

public class EnemyFollow : MonoBehaviour
{
	private Player player;
	[SerializeField] private float agrRange;
	[SerializeField] private float speed;
	private Rigidbody2D rb;
	private void Start()
	{
		player = Player.Instance;
		rb = GetComponent<Rigidbody2D>();
	}


	void FixedUpdate()
	{
		float distance = Vector3.Distance(transform.position, player.transform.position);
		if (distance < agrRange && distance > 2)
		{
			Vector2 direction = (Vector2)player.transform.position - rb.position;

			direction.Normalize();

			rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
		}

	}
}

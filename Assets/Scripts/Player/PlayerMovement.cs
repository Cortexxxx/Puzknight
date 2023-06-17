using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 1;
	private Vector3 moveDelta;
	private Rigidbody2D rb;
	private Animator animator;

	private void Start()
	{
        rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

	}

	private void FixedUpdate()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		moveDelta = new Vector3(x, y, 0);
		rb.AddForce(moveDelta.normalized * Time.deltaTime * speed, ForceMode2D.Impulse);
		if (moveDelta != Vector3.zero)
		{
			animator.SetFloat("MoveX", moveDelta.x);
			animator.SetFloat("MoveY", moveDelta.y);
			animator.SetBool("Moving", true);
		}
		else
		{
			rb.velocity = Vector2.zero;
			animator.SetBool("Moving", false);
		}


	}

}

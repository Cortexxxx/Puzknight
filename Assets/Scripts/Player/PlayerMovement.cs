using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 1;
	private Vector3 moveDelta;
	private Rigidbody2D rb;
	private Animator animator;
	private AudioSource audioSource;
	[SerializeField] private AudioClip walkClip;
	private void Start()
	{
        rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();

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
			if (audioSource.isPlaying == false)
			{
				audioSource.clip = walkClip;
				audioSource.Play();
			}

		}
		else
		{
			audioSource.Stop();

			rb.velocity = Vector2.zero;
			animator.SetBool("Moving", false);
		}


	}

}

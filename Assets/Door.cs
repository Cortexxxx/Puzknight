using UnityEngine;

public class Door : MonoBehaviour
{
	private Animator animator;
	private BoxCollider2D boxCollider2D;
	private void Start()
	{
		animator = GetComponent<Animator>();
		boxCollider2D = GetComponent<BoxCollider2D>();
	}
	public void Toggle()
	{
		animator.SetBool("Toggle", !animator.GetBool("Toggle"));
		boxCollider2D.enabled = !boxCollider2D.enabled;

	}
}

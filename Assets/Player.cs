using UnityEngine;


public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Animator animator;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    Rigidbody2D rb;
    public static Player instance;
    [SerializeField] private float speed = 1;
    public Interactable interactingWith;
	private void Awake()
	{
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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

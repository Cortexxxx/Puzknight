using UnityEngine;

public class Arrow : MonoBehaviour
{
	[SerializeField] private AudioClip clip;
	private void Awake()
	{
		GetComponent<Rigidbody2D>().AddForce(new Vector2(15,0), ForceMode2D.Impulse);
		GetComponent<AudioSource>().PlayOneShot(clip);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() != null)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			Player.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
			Player.Instance.Kill();
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}
	private void Update()
	{
		if (Player.Instance.IsDead)
		{
			Destroy(gameObject, 0.9f);
		}
	}
}

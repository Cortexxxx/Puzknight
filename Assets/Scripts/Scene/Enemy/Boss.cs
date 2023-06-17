using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
	[SerializeField] private int health;
	[SerializeField] private GameObject keyPrefab;
	public int Health
	{
		get
		{
			return health;
		}
		set
		{
			if (value >= 0)
			{
				health = value;
				UIContainer.Instance.bossHealthBar.GetComponent<Slider>().value = health;	
			}
			else
			{
				health = 0;
			}
			if (health == 0)
			{
				GetComponent<Animator>().SetTrigger("Death");
				GetComponent<EnemyFollow>().enabled = false;
			}
		}
	}
	private void Start()
	{
		BossHealthBar bossHealthBar = UIContainer.Instance.bossHealthBar.GetComponent<BossHealthBar>();
		bossHealthBar.gameObject.SetActive(true);
		bossHealthBar.GenerateLines(health);

	}
	private void KillBoss()
	{
		Instantiate(keyPrefab, transform.position, Quaternion.identity);
		BossHealthBar bossHealthBar = UIContainer.Instance.bossHealthBar.GetComponent<BossHealthBar>();
		bossHealthBar.gameObject.SetActive(false);
		Destroy(gameObject);
	}
}

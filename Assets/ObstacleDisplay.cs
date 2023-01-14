using UnityEngine;
using UnityEngine.U2D;
[RequireComponent(typeof(Collider2D))]
public class ObstacleDisplay : MonoBehaviour
{
	private Collider2D collider2D;
	private SpriteRenderer[] spriteRenderer;
	private void Start()
	{
		collider2D = GetComponent<Collider2D>();
		spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
	}

	private void Update()
	{
		for (int i = 0; i < spriteRenderer.Length; i++)
		{
			if (Player.instance.transform.position.y - spriteRenderer[i].transform.position.y > 0)
			{
				spriteRenderer[i].sortingLayerName = "Props - Upon Player";
			}
			else
			{
				spriteRenderer[i].sortingLayerName = "Props - Under Player";
			}
		}
	}
}

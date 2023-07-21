using UnityEngine;
public class ObstacleDisplay : MonoBehaviour
{
	private enum Type
	{
		Sprite,
		Collider
	}
	[SerializeField] private Type type;
	private SpriteRenderer[] spriteRenderer;
	private void Start()
	{
		spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
	}

	private void Update()
	{
		switch (type)
		{
			case Type.Sprite:
				for (int i = 0; i < spriteRenderer.Length; i++)
				{
					if (Player.Instance.transform.position.y - spriteRenderer[i].transform.position.y > 0)
					{
						spriteRenderer[i].sortingLayerName = "PropsUponPlayer";
					}
					else
					{
						spriteRenderer[i].sortingLayerName = "PropsUnderPlayer";
					}
				}
				break;
			case Type.Collider:
				for (int i = 0; i < spriteRenderer.Length; i++)
				{
					if (Player.Instance.GetComponent<BoxCollider2D>().bounds.center.y - spriteRenderer[i].GetComponent<BoxCollider2D>().bounds.center.y > 0)
					{
						spriteRenderer[i].sortingLayerName = "PropsUponPlayer";
					}
					else
					{
						spriteRenderer[i].sortingLayerName = "PropsUnderPlayer";
					}
				}
				break;
			default:
				break;
		}



	}
}

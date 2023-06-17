using UnityEngine;
using UnityEngine.UIElements;

public class Balance : MonoBehaviour
{
	enum State
	{
		Balance,
		Left,
		Right
	}
	private State currentState = State.Balance;
	[SerializeField] private Sprite balanceSprite;
	[SerializeField] private Sprite leftSprite;
	[SerializeField] private Sprite rightSprite;
	[SerializeField] private GameObject right;
	[SerializeField] private GameObject left;
	[SerializeField] private float downY;
	[SerializeField] private float topY;
	[SerializeField] private float midY;
	private State CurrentState
	{
		get {
			return currentState;
		}
		set {
			currentState = value;
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			switch (currentState)
			{
				case State.Balance:
					GetComponent<SpriteRenderer>().sprite = balanceSprite;
					right.transform.localPosition = new Vector2 (right.transform.localPosition.x, midY);
					left.transform.localPosition = new Vector2 (left.transform.localPosition.x, midY);
					break;
				case State.Right:
					GetComponent<SpriteRenderer>().sprite = rightSprite;
					right.transform.localPosition = new Vector2(right.transform.localPosition.x, topY);
					left.transform.localPosition = new Vector2(left.transform.localPosition.x, downY);
					break;
				case State.Left:
					GetComponent<SpriteRenderer>().sprite = leftSprite;
					left.transform.localPosition = new Vector2(left.transform.localPosition.x, topY);
					right.transform.localPosition = new Vector2(right.transform.localPosition.x, downY);
					break;
				default:
					break;
			}
		}
	}
	private void Start()
	{
		CurrentState = State.Balance;
	}

}

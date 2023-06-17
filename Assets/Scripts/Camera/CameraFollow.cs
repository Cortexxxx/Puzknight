using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float boundX = 0.15f;
    [SerializeField] private float boundY = 0.05f;
    private void LateUpdate()
    {
		if (target == null)
        {
            target = Player.Instance.transform;
        }

        Vector3 delta = Vector3.zero;

        float deltaX = target.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < target.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = target.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < target.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y);
    }
    private void Update() {
		if (SceneManager.GetActiveScene().buildIndex == 0) {
            Destroy(gameObject);
        }
	}
	private void Start()
	{
        DontDestroyOnLoad(gameObject);
	}
}

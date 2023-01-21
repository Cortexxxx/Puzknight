using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[HideInInspector] public static Player instance;
    [HideInInspector] public Interactable interactingWith;
	 public Pickupable holdingItem;

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
	private void Update()
	{
		if (holdingItem != null && !UIContainer.Instance.dropButton.activeInHierarchy)
		{
			Button dropButton = UIContainer.Instance.dropButton.GetComponent<Button>();
			dropButton.gameObject.SetActive(true);
			dropButton.onClick.RemoveAllListeners();
			dropButton.onClick.AddListener(dropButton.GetComponent<DropButton>().Drop);
		}
		else if (holdingItem == null && UIContainer.Instance.dropButton.activeInHierarchy)
		{
			UIContainer.Instance.dropButton.SetActive(false);
		}
	}

}

using UnityEngine;


public class Player : MonoBehaviour
{
	[HideInInspector] public static Player instance;
    [HideInInspector] public Interactable interactingWith;
	[HideInInspector] public Pickupable holdingItem;

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

}

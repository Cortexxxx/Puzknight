using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[HideInInspector] public static Player Instance;
    [HideInInspector] public Interactable interactingWith;
	public Pickupable holdingItem;
	public bool IsDead { get; set; } 
	private void Awake()
	{
        if (Instance == null)
        {
			Instance = this;
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
	public void Kill()
	{
		GetComponent<Animator>().SetTrigger("Death");
		GetComponent<PlayerMovement>().enabled = false;
		IsDead = true;
		StartCoroutine(LevelManager.Instance.RestartLevel());
	}


}

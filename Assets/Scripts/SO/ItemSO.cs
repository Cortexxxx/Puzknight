using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Item")]
public class ItemSO : ScriptableObject
{
	[SerializeField] private RecipeSO recipe;
	public GameObject prefab;
	public string Name;
	public float weight; // in kilos
}

using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Item/Recipe")]
public class RecipeSO : ScriptableObject
{
	public ItemSO[] items = new ItemSO[4];
	public ItemSO item;
}

using UnityEngine;

[CreateAssetMenu(fileName = "StoveSO", menuName = "Scriptable Objects/StoveSO")]
public class StoveSO : ScriptableObject
{
    public KitchenObjectSO uncooked;
    public  KitchenObjectSO cooked;
    public   KitchenObjectSO burned;
    public  int cookingTime;
    
}

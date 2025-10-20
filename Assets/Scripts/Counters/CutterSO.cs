using UnityEngine;

[CreateAssetMenu(fileName = "CutterSO", menuName = "Scriptable Objects/CutterSO")]
public class CutterSO : ScriptableObject
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public int maxCutNumber = 3; 
    
}

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecepieSO", menuName = "Scriptable Objects/RecepieSO")]
public class RecepieSO : ScriptableObject
{
    public string name;
    public List<KitchenObjectSO> recepieList;
}

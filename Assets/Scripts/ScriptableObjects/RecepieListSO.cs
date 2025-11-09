using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecepieListSO", menuName = "Scriptable Objects/RecepieListSO")]
public class RecepieListSO : ScriptableObject
{
    public List<RecepieSO> list;
}

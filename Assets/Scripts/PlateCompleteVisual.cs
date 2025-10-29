using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class PlateCompleteVisual : MonoBehaviour
{
    [SerializeField] private Plate plate;
    [Serializable]
    public struct PlateVisualIngredient
    {
        public KitchenObjectSO so;
        public GameObject gObj;
    }
    [SerializeField] private List<PlateVisualIngredient> plateVisualIngredientList;
    private void Start()
    {
        plate.OnIngredientAdded += Plate_OnIngredientAdded;
        foreach (PlateVisualIngredient ing in plateVisualIngredientList)
        {
            ing.gObj.SetActive(false);
        }
    }

    private void Plate_OnIngredientAdded(object sender, Plate.OnIngredientAddedEvents e)
    {
        foreach(PlateVisualIngredient ing in plateVisualIngredientList)
        {
            if(ing.so == e.kitchenObjectSO)
            {
                ing.gObj.SetActive(true);
            }
        }
    }
}

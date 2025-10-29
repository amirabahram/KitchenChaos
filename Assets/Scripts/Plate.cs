using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Plate : KitchenObject
{
    private List<KitchenObjectSO> kitchenObjectSOList;
    [SerializeField] private List<KitchenObjectSO> validIngredients;
    [SerializeField] private GameObject completePlate;
    public event EventHandler<OnIngredientAddedEvents> OnIngredientAdded;
    public class OnIngredientAddedEvents: EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

    private void Start()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddddIngredient(KitchenObjectSO ingredient)
    {
        if (!validIngredients.Contains(ingredient)) return false;
        if (kitchenObjectSOList.Contains(ingredient)) return false;
        kitchenObjectSOList.Add(ingredient);
        OnIngredientAdded?.Invoke(this,new OnIngredientAddedEvents { kitchenObjectSO = ingredient});
        return true;

    }
    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }

}

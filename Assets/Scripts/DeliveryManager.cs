using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecepieAddOrDelete;
    public static DeliveryManager Instance;
    [SerializeField] int maxNumOfOrder=4;
    [SerializeField] int orderInterval=4;
    [SerializeField] RecepieListSO recepieListSO;
    private float timer = 0;
    private List<RecepieSO> orders; 
    private void Awake()
    {
        if (Instance == null) Instance = this;
        orders = new List<RecepieSO>();
    }
    public List<RecepieSO> GetOrders()
    {
        return orders;
    }
    private void Update()
    {
        if (orders.Count <= maxNumOfOrder) timer = timer + Time.deltaTime;

        if (timer > orderInterval)
        {
            RecepieSO recepie = recepieListSO.list[UnityEngine.Random.Range(0, recepieListSO.list.Count)];
            orders.Add(recepie);
            OnRecepieAddOrDelete?.Invoke(this,EventArgs.Empty);
            Debug.Log(recepie.name);
            timer = 0;
        }
    }
    public bool RecepieDelivered(Plate platekitchenObject)
    {
        foreach (RecepieSO recepie in orders)
        {
            if(recepie.recepieList.Count != platekitchenObject.GetPlateIngredients().Count) continue;
            
            foreach (KitchenObjectSO ko in platekitchenObject.GetPlateIngredients())
            {
                bool ingredientFound = false;
                foreach(KitchenObjectSO ob in recepie.recepieList)
                {
                    if (ob == ko) ingredientFound = true;
                }
                if (!ingredientFound) break;
                orders.Remove(recepie);
                OnRecepieAddOrDelete?.Invoke(this, EventArgs.Empty);
                Debug.Log("Order Delivered!");
                return true;

            }

        }
        return false;

    }
}

using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerOpenContainer;

    [SerializeField] private KitchenObjectSO so;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
            }
        }
    }
    public override void Interact(Player player)
    {
        if (player.GetCurrentKitchenObject() != null) return;
        if (this.kitchenObject == null)
        {
            SpawnKitchenObjectFromSO(so);
        }
        else
        {
            this.kitchenObject.SetParent(player);
            OnPlayerOpenContainer?.Invoke(this, EventArgs.Empty);
        }
    }
     



    

}

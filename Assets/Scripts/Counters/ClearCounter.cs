using UnityEngine;

public class ClearCounter : BaseCounter
{
    private void Update()
    {

    }
    public override void Interact(Player player)
    {
        if (player.GetCurrentKitchenObject() != null && this.kitchenObject == null)
        {
            kitchenObject = player.GetCurrentKitchenObject();
            kitchenObject.SetParent(this);
            return;
        }
        if (player.GetCurrentKitchenObject() != null && this.kitchenObject != null)
        {
            if (this.GetCurrentKitchenObject().TryGetPlateKitchenObject(out Plate plateKitchenObject))
            {
                if (plateKitchenObject.TryAddddIngredient(player.GetCurrentKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetCurrentKitchenObject().Destroyself();
                    return;
                }
            }

            if (player.GetCurrentKitchenObject().TryGetPlateKitchenObject(out plateKitchenObject))
        {
            if (plateKitchenObject.TryAddddIngredient(GetCurrentKitchenObject().GetKitchenObjectSO()))
            {
                kitchenObject.Destroyself();
            }
        }
                return;
        }
        if (this.kitchenObject!=null)
        {
            this.kitchenObject.SetParent(player);

        }
        

    }

}

using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if(player.GetCurrentKitchenObject().TryGetPlateKitchenObject(out Plate plateKitchenObject))
        {
            DeliveryManager.Instance.RecepieDelivered(plateKitchenObject);
            plateKitchenObject.Destroyself();
        }
    }

}

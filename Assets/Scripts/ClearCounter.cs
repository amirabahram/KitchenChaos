using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO so;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject!=null)
            {
            }
        }
    }
    public override void Interact(Player player)
    {
        if (player.GetCurrentKitchenObject() != null && this.kitchenObject == null)
        {
            kitchenObject.SetParent(this);
            Debug.Log("Counter Class Current Parent" + kitchenObject.GetParent());
            return;
        }
        if (this.kitchenObject!=null)
        {
            this.kitchenObject.SetParent(player);

        }
        

    }

}

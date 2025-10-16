using UnityEngine;

public class CutterCounter : BaseCounter
{
    [SerializeField] private CutterSO[] CutterSO;
    private KitchenObjectSO cutKitchenObjectSo;
    public override void Interact(Player player)
    {
        if (player.GetCurrentKitchenObject() != null && this.kitchenObject == null)
        {
            kitchenObject = player.GetCurrentKitchenObject();
            kitchenObject.SetParent(this);
            cutKitchenObjectSo = kitchenObject.GetKitchenObjectSO();
            return;
        }
        if (this.kitchenObject != null)
        {
            this.kitchenObject.SetParent(player);

        }


    }
    public override void InteractAlternate(Player player)
    {
        if (!this.kitchenObject) return;
        foreach(var r in CutterSO)
        {
            if(cutKitchenObjectSo == r.input) 
            {
                this.kitchenObject.Destroyself();
                Transform sliced = Instantiate(r.output.prefab, spawnPoint);
                sliced.gameObject.GetComponent<KitchenObject>().SetParent(this);
             
            }
        }


    }
}

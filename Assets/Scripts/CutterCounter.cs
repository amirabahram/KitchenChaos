using System;
using UnityEngine;

public class CutterCounter : BaseCounter
{
    public event EventHandler<OnCutEventArgs> OnCut;
    public class OnCutEventArgs : EventArgs
    {
        public float progressNormalized;
    }
    int numOfCuts = 0;
    [SerializeField] private CutterSO[] CutterSO;
    private CutterSO currentCutterSO;
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
    public override void InteractAlternate()
    {
        if (!this.kitchenObject) return;
        foreach(var r in CutterSO)
        {
            if(cutKitchenObjectSo == r.input) 
            {
                currentCutterSO = r;
                numOfCuts++;
                OnCut?.Invoke(this, new OnCutEventArgs
                {
                    progressNormalized = numOfCuts / (float)currentCutterSO.maxCutNumber
                });
                if(numOfCuts == r.maxCutNumber)
                {
                    this.kitchenObject.Destroyself();
                    Transform sliced = Instantiate(r.output.prefab, spawnPoint);
                    sliced.gameObject.GetComponent<KitchenObject>().SetParent(this);
                    numOfCuts = 0; 
                    break;
                }

             
            }
        }


    }
    public CutterSO GetCurrentCutterSO()
    {
        return currentCutterSO;
    }
}

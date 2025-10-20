using System;
using UnityEngine;
using UnityEngine.UI;

public class CutterCounter : BaseCounter,IHasProgressBar
{

    int numOfCuts = 0;
    [SerializeField] private CutterSO[] CutterSO;
    private CutterSO currentCutterSO;
    private KitchenObjectSO cutKitchenObjectSo;

    public event EventHandler<IHasProgressBar.OnActionEventArgs> OnActionHappen;

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
                OnActionHappen?.Invoke(this, new IHasProgressBar.OnActionEventArgs
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

    public void progressValueChanged(float value)
    {
        throw new NotImplementedException();
    }
}

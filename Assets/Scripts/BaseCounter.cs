using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjecParent
{
    
    [SerializeField] protected Transform spawnPoint;
    protected KitchenObject kitchenObject;
    public virtual void Interact(Player newParent) {
        Debug.LogError("Call Interact fron baseCounter");
    }
    public virtual void InteractAlternate(Player newParent)
    {
        Debug.LogError("Call InteractAlternate fron baseCounter");
    }
    public Transform GetSpawnPointforKitchenObject()
    {
        return spawnPoint;
    }
    public void ClearKitchenObjectParent()
    {
        kitchenObject = null;
    }
    public void SetKitchenObjectForParent(KitchenObject ki)
    {
        kitchenObject = ki;
    }
    public KitchenObject GetCurrentKitchenObject()
    {
        return kitchenObject;
    }
}

using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjecParent
{
    
    [SerializeField] protected Transform spawnPoint;
    protected KitchenObject kitchenObject;
    public virtual void Interact(Player newParent) {
        Debug.LogError("Call Interact fron baseCounter");
    }
    public virtual void InteractAlternate()
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
    public void SpawnKitchenObjectFromSO(KitchenObjectSO so)
    {
        Transform temp = Instantiate(so.prefab, spawnPoint);
        temp.gameObject.GetComponent<KitchenObject>().SetParent(this);
    }
}

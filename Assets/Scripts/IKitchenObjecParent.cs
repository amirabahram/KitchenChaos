using UnityEngine;

public interface IKitchenObjecParent
{
    public Transform GetSpawnPointforKitchenObject();
    public void ClearKitchenObjectParent();
    public void SetKitchenObjectForParent(KitchenObject ki);
    public KitchenObject GetCurrentKitchenObject();
}

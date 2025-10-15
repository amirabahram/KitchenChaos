using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private IKitchenObjecParent parent;

    public IKitchenObjecParent GetParent()
    {
        return parent;
    }
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
    public void ClearParent()
    {
        parent = null;
    }
    public void SetParent(IKitchenObjecParent parent)
    {
        ClearParent();
        this.parent = parent;
        transform.parent = this.parent.GetSpawnPointforKitchenObject();
        transform.localPosition = Vector3.zero;
        Debug.Log(this.parent);

    }
}

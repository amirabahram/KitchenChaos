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
    public void SetParent(IKitchenObjecParent parent)
    {
        if(this.parent != null) 
        this.parent.ClearKitchenObjectParent();
        this.parent = parent;
        parent.SetKitchenObjectForParent(this);
        transform.parent = this.parent.GetSpawnPointforKitchenObject();
        transform.localPosition = Vector3.zero;

    }
    public bool TryGetPlateKitchenObject(out Plate plateKitchenObject)
    {
        if(this is Plate)
        {
            plateKitchenObject = this as Plate;
            return true;
        }
        plateKitchenObject = null;
        return false;
    }
    public void Destroyself()
    {
        this.parent.ClearKitchenObjectParent();
        Destroy(this.gameObject);
    }
}

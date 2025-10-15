using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO so;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
            }
        }
    }
    public override void Interact(Player newParent)
    {
        if (kitchenObject == null)
        {
            Transform tom = Instantiate(so.prefab, spawnPoint);
            tom.localPosition = Vector3.zero;
            kitchenObject = tom.gameObject.GetComponent<KitchenObject>();
            kitchenObject.SetParent(this);
        }
        else
        {
            kitchenObject.SetParent(newParent);
        }


    }

}

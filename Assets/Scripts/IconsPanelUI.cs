using System;
using UnityEngine;

public class IconsPanelUI : MonoBehaviour
{
    [SerializeField] Plate plate;
    [SerializeField] Transform icon;

    private void Awake()
    {
        icon.gameObject.SetActive(false);
    }
    private void Start()
    {
        plate.OnIngredientAdded += Plate_OnIngredientAdded;
        foreach (Transform child in transform)
        {
            if (child == icon) continue;
            Destroy(child.gameObject);
        }
    }

    private void Plate_OnIngredientAdded(object sender, Plate.OnIngredientAddedEvents e)
    {
        UpdateIcons();
    }

    private void UpdateIcons()
    {
        foreach(Transform child in transform)
        {
            if (child == icon) continue;
            Destroy(child.gameObject);
        }
        foreach(KitchenObjectSO so in plate.GetKitchenObjectSOList())
        {
            Transform newIcon = Instantiate(icon, transform);
            newIcon.gameObject.SetActive(true);
            newIcon.GetComponent<IconUI>().newIngredientAdded(so.sprite);
        }
    }
}

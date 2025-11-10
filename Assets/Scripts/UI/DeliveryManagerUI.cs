using TMPro;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] Transform template;

    private void Start()
    {
        if(DeliveryManager.Instance != null) DeliveryManager.Instance.OnRecepieAddOrDelete += Instance_OnRecepieAddOrDelete;
        UpdateUI();
        template.gameObject.SetActive(false);
    }

    private void Instance_OnRecepieAddOrDelete(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        foreach(Transform child in container)
        {
            if (child == template) continue; 
            Destroy(child.gameObject);
        }
        
        foreach (RecepieSO recepie in DeliveryManager.Instance.GetOrders())
        {
            Transform recepieConteiner = Instantiate(template, container);
            recepieConteiner.gameObject.SetActive(true);
            recepieConteiner.GetComponent<RecepieSingleUI>().updateIcons(recepie);
        }
    }
}

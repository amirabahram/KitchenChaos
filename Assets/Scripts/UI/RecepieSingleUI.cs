using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RecepieSingleUI : MonoBehaviour
{
    [SerializeField] Transform icontemplate;
    [SerializeField] Transform iconContainer;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        icontemplate.gameObject.SetActive(false);
    }
    public void updateIcons(RecepieSO recepie)
    {
        foreach(Transform child in iconContainer)
        {
            if (child == icontemplate) continue;
            Destroy(child.gameObject);
        }
        textMeshProUGUI.text = recepie.name;
        foreach(KitchenObjectSO ko in recepie.recepieList)
        {
            Transform newIcon = Instantiate(icontemplate, iconContainer);
            newIcon.gameObject.SetActive(true);
            newIcon.GetComponent<UnityEngine.UI.Image>().sprite= ko.sprite;

        }
    }
}

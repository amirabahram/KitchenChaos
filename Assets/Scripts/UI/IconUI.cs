using UnityEngine;
using UnityEngine.UI;

public class IconUI : MonoBehaviour
{
    [SerializeField] private Image image;

    public void newIngredientAdded(Sprite sprite)
    {
        image.sprite = sprite;
    }
}

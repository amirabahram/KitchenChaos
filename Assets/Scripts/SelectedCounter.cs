using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField] private BaseCounter selectedCounter;
    [SerializeField] private GameObject[] highLightCounter;
    private void Start()
    {
        Player.Instanse.onSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedArgs e)
    {
        if(e.selectedCounter == selectedCounter)
        {
            setEnable();
            return;
        }
        setDisable();
    }

    public void setEnable()
    {
        foreach(var ob in highLightCounter)
        {
            ob.gameObject.SetActive(true);

        }
    }
    public void setDisable()
    {
        foreach (var ob in highLightCounter)
        {
            ob.gameObject.SetActive(false);

        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CutterUI : MonoBehaviour
{
    [SerializeField]  private  CutterCounter cutterCounter;
    [SerializeField]  private GameObject cutterVisual;
    [SerializeField] private Image image;
    private Animator anim;
    
    private void Start()
    {
        anim = cutterVisual.GetComponent<Animator>();
        cutterCounter.OnCut += CutterCounter_OnCut;
        Disable();
    }

    private void CutterCounter_OnCut(object sender, CutterCounter.OnCutEventArgs e)
    {
        Enable();
        image.fillAmount = e.progressNormalized;
        anim.SetTrigger("Cut");
        if (e.progressNormalized==1)
        {
            Disable();
        }
    }
    private void Enable()
    {
        gameObject.SetActive(true);
    }
    private void Disable()
    {
        gameObject.SetActive(false);
    }
}

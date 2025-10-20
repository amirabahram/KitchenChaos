using UnityEngine;
using UnityEngine.UI;

public class ProgressUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField]  private  Image image;

    private IHasProgressBar hasProgress;

    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgressBar>();
        hasProgress.OnActionHappen += Action_OnHappend;
        Disable();
    }

    private void Action_OnHappend(object sender, IHasProgressBar.OnActionEventArgs e)
    {
        Enable();
        image.fillAmount = e.progressNormalized;
        //anim.SetTrigger("Cut");
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

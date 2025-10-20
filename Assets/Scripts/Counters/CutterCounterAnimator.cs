using UnityEngine;

public class CutterCounterAnimator : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private CutterCounter cutterCounter;
    private void Start()
    {
        anim = GetComponent<Animator>();
        cutterCounter.OnActionHappen += CutterCounter_OnActionHappen;
    }

    private void CutterCounter_OnActionHappen(object sender, IHasProgressBar.OnActionEventArgs e)
    {
        anim.SetTrigger("Cut");
    }
}

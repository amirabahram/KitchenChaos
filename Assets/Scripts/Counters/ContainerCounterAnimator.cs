using UnityEngine;

public class ContainerCounterAnimator : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private ContainerCounter containerCounter;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        containerCounter.OnPlayerOpenContainer += ContainerCounter_OnPlayerOpenContainer;   
    }

    private void ContainerCounter_OnPlayerOpenContainer(object sender, System.EventArgs e)
    {
        anim.SetTrigger("OpenClose");
    }
}

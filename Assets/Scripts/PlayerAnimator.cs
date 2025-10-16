using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    [SerializeField] Player player;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("IsWalking", player.IsWalking());

    }

}

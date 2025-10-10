using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private GameInput gameInput;
    private Animator anim;
    private bool isWalking = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Vector2 inputVec  = gameInput.GetInputVectorNormalized();
        Vector3 moveDir = new Vector3(inputVec.x,0, inputVec.y);
        float movDistance = Time.deltaTime * speed; 
        float playerSize = 2f;
        float playerRadius = 0.7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerSize, playerRadius, moveDir, movDistance);
        if (canMove) transform.position += moveDir* movDistance;
        float rotateSpeed = 5f;
        transform.forward = Vector3.Slerp(transform.forward,moveDir, rotateSpeed*Time.deltaTime);
        isWalking = moveDir != Vector3.zero;

    }
    public bool IsWalking()
    {
        return isWalking;
    }
}

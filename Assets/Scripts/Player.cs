using System;
using System.Buffers.Text;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour,IKitchenObjecParent
{
    public static Player Instanse { get;private set; }
    public event EventHandler<OnSelectedCounterChangedArgs> onSelectedCounterChanged;
    public class OnSelectedCounterChangedArgs : EventArgs 
    {
        public BaseCounter selectedCounter;
    }
    [SerializeField] private float speed = 10;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;
    [SerializeField] private Transform grabPosition;

    private Animator anim;
    private bool isWalking = false;
    private Vector3 lastInteractDir;
    private KitchenObject kitchenObject;
    private BaseCounter baseCounter;
    private void Awake()
    {
        Instanse = this;
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;
    }

    private void GameInput_OnInteractAlternateAction(object sender, EventArgs e)
    {
        Vector2 inputVec = gameInput.GetInputVectorNormalized();
        Vector3 moveDir = new Vector3(inputVec.x, 0, inputVec.y);
        float interactDistance = 2f;
        if(moveDir != Vector3.zero ) lastInteractDir = moveDir;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit hit, interactDistance, counterLayerMask)) ;
        {
            if (hit.transform.TryGetComponent(out BaseCounter counter))
            {
                counter.InteractAlternate(this);
            }
        }
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        Vector2 inputVec = gameInput.GetInputVectorNormalized();
        Vector3 moveDir = new Vector3(inputVec.x, 0, inputVec.y);
        float interactDistance = 2f;
        if (moveDir != Vector3.zero) lastInteractDir = moveDir;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter counter)){
                 counter.Interact(this); 
                
            }

        }
    }

    void Update()
    {
        HandleMovement();
        HandleInteraction();


    }

    private void HandleInteraction()
    {
        Vector2 inputVec = gameInput.GetInputVectorNormalized();
        Vector3 moveDir = new Vector3(inputVec.x, 0, inputVec.y);
        float interactDistance = 2f;
        if (moveDir != Vector3.zero) lastInteractDir = moveDir;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseC))
            {
                if (this.baseCounter != baseC)
                {
                    this.baseCounter = baseC;
                    onSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedArgs { selectedCounter = baseC });
                }
            }
            else
            {
                this.baseCounter = null;
                onSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedArgs { selectedCounter = baseC });
            }
        }
        else
        {
            this.baseCounter = null;
            onSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedArgs { selectedCounter = baseCounter});
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVec = gameInput.GetInputVectorNormalized();
        Vector3 moveDir = new Vector3(inputVec.x, 0, inputVec.y);
        float movDistance = Time.deltaTime * speed;
        float playerSize = 2f;
        float playerRadius = 0.7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerSize, playerRadius, moveDir, movDistance);
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = moveDir.x!=0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerSize, playerRadius, moveDirX, movDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = moveDir.z!=0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerSize, playerRadius, moveDirZ, movDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }

            }
        }
        if(canMove) transform.position += moveDir * movDistance;
        float rotateSpeed = 5f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
        isWalking = moveDir != Vector3.zero;
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public Transform GetSpawnPointforKitchenObject()
    {
        return grabPosition;
    }

    public void SetKitchenObjectForParent(KitchenObject ki)
    {
        kitchenObject = ki;
    }

    public KitchenObject GetCurrentKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObjectParent()
    {
        kitchenObject = null;
    }

}

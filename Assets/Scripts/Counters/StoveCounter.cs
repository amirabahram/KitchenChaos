using System;
using Unity.VisualScripting;
using UnityEngine;

public class StroveCounter : BaseCounter,IHasProgressBar
{
    [SerializeField ]private StoveSO stoveSO;
    public enum State{
        idle,
        frying,
        fried,
        burned
    }
    State state = State.idle;
    float timer;

    public event EventHandler<IHasProgressBar.OnActionEventArgs> OnActionHappen;

    private void Update()
    {
        if (this.GetCurrentKitchenObject() == null) {
            if (state == State.burned) state = State.idle;
            return;
        }
        

        switch (state)
        {
            case State.idle:
                state = State.frying;
                break;
            case State.frying:
                timer += Time.deltaTime;

                if (timer > stoveSO.cookingTime)
                {
                    timer = 0;
                    state = State.fried;
                    kitchenObject.Destroyself();
                    SpawnKitchenObjectFromSO(stoveSO.cooked);
                }
                OnActionHappen?.Invoke(this,
    new IHasProgressBar.OnActionEventArgs { progressNormalized = timer / (float)stoveSO.cookingTime });
                break;
            case State.fried:
                timer += Time.deltaTime;

                if (timer > stoveSO.cookingTime)
                {
                    timer = 0;
                    state = State.burned;
                    kitchenObject.Destroyself();
                    SpawnKitchenObjectFromSO(stoveSO.burned);
                }
                OnActionHappen?.Invoke(this,
    new IHasProgressBar.OnActionEventArgs { progressNormalized = timer / (float)stoveSO.cookingTime });
                break;
            case State.burned:
                OnActionHappen?.Invoke(this,
new IHasProgressBar.OnActionEventArgs { progressNormalized = 1 });

                break;
        }
    }
    public override void Interact(Player player)
    {
        if (player.GetCurrentKitchenObject() != null && this.kitchenObject == null)
        {
            kitchenObject = player.GetCurrentKitchenObject();
            kitchenObject.SetParent(this);
            return;
        }
        if (this.kitchenObject != null)
        {
            this.kitchenObject.SetParent(player);
            this.kitchenObject = null;
        }


    }
    public override void InteractAlternate()
    {
        


    }
}

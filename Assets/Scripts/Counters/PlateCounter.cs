using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    public event EventHandler OnPlateSpawn;
    public event EventHandler<OnPlatePickedEventArgs> OnPlatePicked;
    public class OnPlatePickedEventArgs : EventArgs
    {
        public Player player;
    }
    [SerializeField] KitchenObjectSO plate;
    [SerializeField] int spawnIntervals = 4;
    [SerializeField] int maximumPlates = 4;
    private int spawnedPlates=0;
    float timer=0;

    private void Start()
    {
  
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnIntervals)
        {
            timer = 0;

            if (spawnedPlates < maximumPlates)
            {
                OnPlateSpawn?.Invoke(this, EventArgs.Empty);
                spawnedPlates++;
            }
        }
    }
    public override void Interact(Player newParent)
    {
        OnPlatePicked?.Invoke(this, new OnPlatePickedEventArgs { player = newParent});
    }
}

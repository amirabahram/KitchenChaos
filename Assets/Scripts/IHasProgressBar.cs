using System;
using UnityEngine;
using UnityEngine.UI;

public interface IHasProgressBar 
{
    public event EventHandler<OnActionEventArgs> OnActionHappen;
    public class OnActionEventArgs : EventArgs
    {
        public float progressNormalized;
    }
}

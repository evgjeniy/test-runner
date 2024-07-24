using UnityEngine;

[System.Serializable]
public class Observable<TValue> : IObservable<TValue>
{
    [SerializeField] private TValue value;

    private event System.Action<TValue> OnChanged = _ => { };

    public virtual TValue Value
    {
        get => value;
        set { this.value = value; OnChanged(this.value); }
    }

    public event System.Action<TValue> Changed
    {
        add { OnChanged += value; value(this.value); }
        remove => OnChanged -= value;
    }

    public Observable(TValue value = default) => this.value = value;

    public static implicit operator TValue(Observable<TValue> observable) => observable.Value;
}
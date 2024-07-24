public interface IObservable<out TValue>
{
    TValue Value { get; }
    event System.Action<TValue> Changed;
}
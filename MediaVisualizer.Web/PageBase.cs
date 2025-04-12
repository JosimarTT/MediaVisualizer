using Microsoft.AspNetCore.Components;

namespace MediaVisualizer.Web;

public class PageBase : ComponentBase, IDisposable
{
    private readonly IList<PersistingComponentStateSubscription> _subscriptions =
        new List<PersistingComponentStateSubscription>();

    [Inject] private PersistentComponentState ComponentState { get; set; }

    public void Dispose()
    {
        foreach (var subscription in _subscriptions)
            subscription.Dispose();
        _subscriptions.Clear();
    }

    protected async Task<TResult?> GetOrAddState<TResult>(string key, Func<Task<TResult?>> addStateFactory)
    {
        TResult? data = default;

        _subscriptions.Add(ComponentState.RegisterOnPersisting(() =>
        {
            ComponentState.PersistAsJson(key, data);
            return Task.CompletedTask;
        }));

        if (ComponentState.TryTakeFromJson(key, out TResult? storedData))
            data = storedData;
        else
            data = await addStateFactory.Invoke();
        return data;
    }
}
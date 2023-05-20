using Fluxor;
using FluxorWidgetsMonospace.Store;
using Microsoft.AspNetCore.Components;

namespace FluxorWidgetsMonospace.Pages;

public partial class Index
{
    [Inject] private IState<DataSpaceState> DataSpaceState { get; set; } = default!;

    [Inject] private IState<WidgetState> WidgetState { get; set; } = default!;

    [Inject] private IDispatcher Dispatcher { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Dispatcher.Dispatch(new DataSpaceInitializedAction());

        Dispatcher.Dispatch(new WidgetInitializedAction(
            1, "All time"
        ));

        Dispatcher.Dispatch(new WidgetInitializedAction(
            2, "10 days"
        ));

        Dispatcher.Dispatch(new WidgetInitializedAction(
            3, "30 days"
        ));

        StateHasChanged();
    }

    private Task PopulateWidget(int widgetId)
    {
        Dispatcher.Dispatch(new WidgetPopulateAction(widgetId, GetRandomized(8)));

        return Task.CompletedTask;
    }

    private int[] GetRandomized(int size)
    {
        var randomIds = new HashSet<int>();

        var ids = DataSpaceState.Value.Entities.Keys.ToArray();

        if (size > ids.Length)
            size = ids.Length;

        var random = new Random();

        for (var i = 0; i < size; i++)
        {
            var r = random.Next(ids.Length);

            randomIds.Add(ids[r]);
        }

        return randomIds.Order().ToArray();
    }
}

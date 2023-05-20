using Fluxor;

namespace FluxorWidgetsMonospace.Store.Effects;

public class WidgetPopulateEffect : Effect<WidgetPopulateAction>
{
    private readonly IState<WidgetState> _widgetState;

    public WidgetPopulateEffect(IState<WidgetState> widgetState)
    {
        _widgetState = widgetState;
    }

    public override Task HandleAsync(WidgetPopulateAction action, IDispatcher dispatcher)
    {
        var targetWidget = _widgetState.Value.Widgets.FirstOrDefault(x => x.Id == action.WidgetId);

        if (targetWidget == null)
            return Task.CompletedTask;

        var itemsToRemove = targetWidget.EntityIds.Except(action.EntityIds).ToList();

        dispatcher.Dispatch(new WidgetPopulatingCompleteAction(action.WidgetId, action.EntityIds));

        var unusedItems = GetUnusedEntities(itemsToRemove).ToArray();

        dispatcher.Dispatch(new DataSpaceRemoveUnusedAction(unusedItems));

        return Task.CompletedTask;
    }

    private IEnumerable<int> GetUnusedEntities(IEnumerable<int> itemsToCheck)
    {
        return itemsToCheck.Where(item =>
            _widgetState.Value.Widgets.All(x => !x.EntityIds.Contains(item))
        );
    }
}
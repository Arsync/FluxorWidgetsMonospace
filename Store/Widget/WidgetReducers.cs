using Fluxor;
using FluxorWidgetsMonospace.Store.Models;

namespace FluxorWidgetsMonospace.Store;

public static class WidgetReducers
{
    [ReducerMethod]
    public static WidgetState OnWidgetInitialized(WidgetState state, WidgetInitializedAction action)
    {
        var widgets = state.Widgets;

        var existingWidget = widgets.FirstOrDefault(x => x.Id == action.Id);

        if (existingWidget != null)
            widgets = widgets.Remove(existingWidget);

        return state with
        {
            Widgets = widgets.Add(
                new WidgetModel(action.Id, action.Name, Array.Empty<int>())
            )
        };
    }

    [ReducerMethod]
    public static WidgetState OnWidgetPopulatingComplete(WidgetState state, WidgetPopulatingCompleteAction action)
    {
        var widgets = state.Widgets;

        var targetWidget = widgets.FirstOrDefault(x => x.Id == action.WidgetId);

        if (targetWidget == null)
            return state;

        return state with
        {
            Widgets = widgets.Remove(targetWidget).Add(
                targetWidget with
                {
                    EntityIds = action.EntityIds
                }
            )
        };
    }
}

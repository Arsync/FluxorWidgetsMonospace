using System.Collections.Immutable;
using Fluxor;
using FluxorWidgetsMonospace.Store.Models;

namespace FluxorWidgetsMonospace.Store;

public static class DataSpaceReducers
{
    [ReducerMethod(typeof(DataSpaceInitializedAction))]
    public static DataSpaceState OnInitialized(DataSpaceState state)
    {
        var entities = new Dictionary<int, EntityModel>
        {
            { 1, new EntityModel(1, "A") },
            { 2, new EntityModel(2, "B") },
            { 3, new EntityModel(1, "C") },
            { 4, new EntityModel(1, "D") },
            { 5, new EntityModel(1, "E") },
            { 6, new EntityModel(1, "F") },
            { 7, new EntityModel(1, "G") },
            { 8, new EntityModel(1, "H") },
            { 9, new EntityModel(1, "I") }
        };

        return state with
        {
            Entities = entities.ToImmutableDictionary()
        };
    }

    [ReducerMethod]
    public static DataSpaceState OnRemoveUnused(DataSpaceState state, DataSpaceRemoveUnusedAction action)
    {
        var removed = state.Entities.Where(x => action.EntityIds.Contains(x.Key))
            .Select(x => new KeyValuePair<int, EntityModel>(x.Key, x.Value));

        var removedEntities = state.RemovedEntities.AddRange(removed);

        return state with
        {
            Entities = state.Entities.RemoveRange(action.EntityIds),
            RemovedEntities = removedEntities
        };
    }
}

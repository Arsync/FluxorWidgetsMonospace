using FluxorWidgetsMonospace.Store.Models;

namespace FluxorWidgetsMonospace.Store;

public static class DataSpaceExtensions
{
    public static EntityModel? GetEntityById(this DataSpaceState state, int entityId)
    {
        return state.Entities.TryGetValue(entityId, out var entity)
            ? entity
            : null;
    }
}

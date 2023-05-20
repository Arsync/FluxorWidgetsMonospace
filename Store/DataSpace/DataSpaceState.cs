using System.Collections.Immutable;
using Fluxor;
using FluxorWidgetsMonospace.Store.Models;

namespace FluxorWidgetsMonospace.Store;

[FeatureState(Name = nameof(DataSpaceState))]
public record DataSpaceState
{
    public ImmutableDictionary<int, EntityModel> Entities { get; init; } = ImmutableDictionary<int, EntityModel>.Empty;

    public ImmutableDictionary<int, EntityModel> RemovedEntities { get; init; } = ImmutableDictionary<int, EntityModel>.Empty;
}

using System.Collections.Immutable;
using Fluxor;
using FluxorWidgetsMonospace.Store.Models;

namespace FluxorWidgetsMonospace.Store;

[FeatureState(Name = nameof(WidgetState))]
public record WidgetState
{
    public ImmutableArray<WidgetModel> Widgets { get; init; } = ImmutableArray<WidgetModel>.Empty;
}

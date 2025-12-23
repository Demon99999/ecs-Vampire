using Code.Infrastructure.Systems;
using Code.Infrastructure.View.System;

namespace Code.Infrastructure.View
{
  public sealed class BindViewFeature : Feature
  {
    public BindViewFeature(ISystemFactory systems)
    {
      Add(systems.Create<BindEntityViewFromPathSystem>());
      Add(systems.Create<BindEntityViewFromPrefabSystem>());
    }
  }
}
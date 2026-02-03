using Code.Common.Destruct;
using Code.Infrastructure.Systems;
using Code.Progress;

namespace Code.Meta
{
  public class HomeScreenFeature : Feature
  {
    public HomeScreenFeature(ISystemFactory systems)
    {
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}
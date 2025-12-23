using System.Collections.Generic;
using Entitas;

namespace Code.Common.Destruct.System
{
  public class CleanupMetaDestructedSystem : ICleanupSystem
  {
    private readonly IGroup<MetaEntity> _entities;
    private readonly List<MetaEntity> _buffer = new List<MetaEntity>(16);

    public CleanupMetaDestructedSystem(MetaContext metaContext) => 
      _entities = metaContext.GetGroup(MetaMatcher.Destructed);

    public void Cleanup()
    {
      foreach (MetaEntity entity in _entities.GetEntities(_buffer)) 
        entity.Destroy();
    }
  }
}
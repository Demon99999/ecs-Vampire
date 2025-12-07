using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common;
using Code.Gameplay.Common.Physics;
using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace Code.Gameplay.Features.TargetCollection.System
{
    public class TargetSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _entitis;
        private List<GameEntity> _buffer = new List<GameEntity>(64);

        public TargetSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            
            _entitis = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.ReadyToCollectTargets,
                    GameMatcher.TargetBuffer,
                    GameMatcher.WorldPosition,
                    GameMatcher.Radius,
                    GameMatcher.LayerMask
                    ));
        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _entitis.GetEntities(_buffer))
            {
                entity.TargetBuffer.AddRange(TargetsInRadius(entity));
                entity.isReadyToCollectTargets = false;
            }
        }

        private IEnumerable<int> TargetsInRadius(GameEntity entity)
        {
           return _physicsService.CircleCast(entity.WorldPosition, entity.Radius, entity.LayerMask).Select(x => x.Id);
        }
    }
}
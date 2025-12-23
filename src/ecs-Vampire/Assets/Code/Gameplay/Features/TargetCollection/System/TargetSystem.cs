using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace Code.Gameplay.Features.TargetCollection.System
{
    public class TargetSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _ready;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(64);

        public TargetSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _ready = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReadyToCollectTargets,
                    GameMatcher.Radius,
                    GameMatcher.TargetBuffer,
                    GameMatcher.WorldPosition,
                    GameMatcher.LayerMask)
            );
        }
        
        
        public void Execute()
        {
            foreach (GameEntity entity in _ready.GetEntities(_buffer))
            {
                entity.TargetBuffer.AddRange(TargetsInRadius(entity));
                
                entity.isReadyToCollectTargets = false;

                //if (!entity.isCollectingTargetsContinuously)
                    //entity.isReadyToCollectTargets = false;
            }
        }
        
        private IEnumerable<int> TargetsInRadius(GameEntity entity)
        {
            return _physicsService.CircleCast(entity.WorldPosition, radius: entity.Radius, entity.LayerMask)
                .Select(x => x.Id);
        }
    }
}
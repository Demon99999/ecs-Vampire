using Code.Common.Extensions;
using Entitas;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Code.Gameplay.Features.Movement.System
{
    public class TurnAlongDirectionSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _movers;

        public TurnAlongDirectionSystem(GameContext gameContext)
        {
            _movers = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.TurnedAlongDirections,
                    GameMatcher.Direction,
                    GameMatcher.SpriteRenderer
                ));
        }
        
        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                float scale = Mathf.Abs(mover.SpriteRenderer.transform.localScale.x);
                mover.SpriteRenderer.transform.SetScaleX(scale * FaceDirection(mover));
            }
        }

        private float FaceDirection(GameEntity mover)
        {
            return mover.Direction.x <= 0 ? -1 : 1;
        }
    }
}
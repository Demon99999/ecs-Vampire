using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.EffectApplication.System
{
    public class ApplyEffectsOnTargetsSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _entities;
        private readonly IEffectFactory _effectFactory;

        public ApplyEffectsOnTargetsSystem(GameContext gameContext, IEffectFactory effectFactory)
        {
            _gameContext = gameContext;
            _effectFactory = effectFactory;
            
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.TargetBuffer,
                    GameMatcher.EffectSetups));
            
        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetId in entity.TargetBuffer)
            foreach (EffectSetup setup in entity.EffectSetups)
            {
                _effectFactory.CreateEffect(setup, ProducerId(entity), targetId);
            }
        }
        
        private static int ProducerId(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}

using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace Code.Gameplay.Features.Cooldowns.System
{
    public class CooldownSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _cooldownables;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);
        
        public CooldownSystem(GameContext gameContext, ITimeService time)
        {
            _time = time;
            _cooldownables = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Cooldown,
                    GameMatcher.CooldownLeft));
        }
        
        public void Execute()
        {
            foreach (GameEntity cooldownable in _cooldownables.GetEntities(_buffer))
            {
                cooldownable.ReplaceCooldownLeft(cooldownable.CooldownLeft - _time.DeltaTime);

                if (cooldownable.CooldownLeft <= 0)
                {
                    cooldownable.isCooldownUp = true;
                    cooldownable.RemoveCooldownLeft();
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Enemies;
using Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Effects;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;

        public EnemyFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
        {
            switch (typeId)
            {
                case EnemyTypeId.Goblin:
                    return CreateGoblin(at);
            }
            
            throw new Exception($"Enemy with type id {typeId} does not exist");
        }

        private GameEntity CreateGoblin(Vector2 at)
        {
            var baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[Stats.Speed] = 1)
                .With(x => x[Stats.MaxHp] = 6)
                .With(x => x[Stats.Damage] = 1);
            
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddEnemyTypeId(EnemyTypeId.Goblin)
                    .AddWorldPosition(at)
                    .AddDirection(Vector2.zero)
                    .AddBaseStats(baseStats)
                    .AddStatModifiers(InitStats.EmptyStatDictionary())
                    .AddSpeed(baseStats[Stats.Speed])
                    .AddCurrentHp(baseStats[Stats.MaxHp])
                    .AddMaxHp(baseStats[Stats.MaxHp])
                    .AddEffectSetups(new List<EffectSetup>{new EffectSetup(){EffectTypeId = EffectTypeId.Damage, Value = baseStats[Stats.Damage]}})
                    .AddTargetBuffer(new List<int>(1))
                    .AddRadius(0.3f)
                    .AddCollectTargetsInterval(0.5f)
                    .AddCollectTargetsTimer(0)
                    .AddLayerMask(CollisionLayer.Hero.AsMask())
                    .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue")
                    .With(x => x.isEnemy = true)
                    .With(x => x.isTurnedAlongDirections = true)
                    .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}
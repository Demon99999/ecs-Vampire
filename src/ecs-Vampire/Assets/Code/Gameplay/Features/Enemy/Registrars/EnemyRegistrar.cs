using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enemies;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.Features.Enemy.Registrars
{
    public class EnemyRegistrar : EntityComponentRegistrar
    { 
        public float Hp = 3f;
        public float Damage = 1f;
        public float Speed = 1;
        
        public override void RegisterComponents()
        {
            Entity
                .AddEnemyTypeId(EnemyTypeId.Goblin)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddCurrentHp(Hp)
                .AddMaxHp(Hp)
                .AddDamage(Damage)
                .AddTargetBuffer(new List<int>(1))
                .AddRadius(0.3f)
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirections = true)
                .With(x => x.isMovementAvailable = true);
        }

        public override void UnregisterComponents()
        {
            
        }
    }
}

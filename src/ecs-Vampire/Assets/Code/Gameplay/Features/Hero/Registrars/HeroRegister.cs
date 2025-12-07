using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;
using TMPro;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegister : EntityComponentRegistrar
    {
        [SerializeField] private float _maxHp = 100f;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private HeroAnimator _heroAnimator;
        
        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(_speed)
                .AddCurrentHp(_maxHp)
                .AddMaxHp(_maxHp)
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirections = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }

        public override void UnregisterComponents()
        {
            
        }
    }
}
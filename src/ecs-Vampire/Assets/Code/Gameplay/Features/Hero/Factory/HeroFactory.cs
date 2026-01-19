using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifiers;

        public HeroFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateHero(Vector3 at)
        {
            var baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[Stats.Speed] = 3)
                .With(x => x[Stats.MaxHp] = 100)
                .With(x => x[Stats.Damage] = 2);
            
            
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddBaseStats(baseStats)
                .AddStatModifiers(InitStats.EmptyStatDictionary())
                .AddSpeed(baseStats[Stats.Speed])
                .AddCurrentHp(baseStats[Stats.MaxHp])
                .AddMaxHp(baseStats[Stats.MaxHp])
                .AddExperience(0)
                .AddViewPath("Gameplay/Hero/hero")
                .AddPickupRadius(1f)
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirections = true)
                .With(x => x.isMovementAvailable = true);
        }
    }
}
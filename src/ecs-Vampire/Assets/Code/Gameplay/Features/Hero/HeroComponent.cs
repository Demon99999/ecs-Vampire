using Code.Gameplay.Features.Hero.Behaviours;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    [Game] public class Hero : IComponent {}
    [Game] public class HeroAnimatorComponent : IComponent { public HeroAnimator Value; }
}
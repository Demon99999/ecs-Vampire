using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Enemy.Behaviours;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
    [Game] public class Enemy : IComponent { }
    [Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
    [Game] public class SpawnTimer : IComponent { public float Value; }
    [Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
}

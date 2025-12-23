using Code.Gameplay.Features.Enemies;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy.Factory
{
    public interface IEnemyFactory
    {
        GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at);
    }
}
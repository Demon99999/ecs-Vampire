using Code.Common.Extensions;
using Code.Gameplay.Cameras.Provider;
using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace Code.Gameplay.Cameras.System
{
    public class CameraFollowHeroSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _heros;
        private ICameraProvider _cameraProvider;

        public CameraFollowHeroSystem(GameContext gameContext, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            
            _heros = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.WorldPosition));
        }
        
        public void Execute()
        {
            foreach (GameEntity hero in _heros)
            {
                _cameraProvider.MainCamera.transform.SetWorldXY(hero.WorldPosition.x, hero.WorldPosition.y);
            }
        }
    }
}
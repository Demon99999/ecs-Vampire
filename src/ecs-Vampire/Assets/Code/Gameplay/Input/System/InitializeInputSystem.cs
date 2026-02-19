using Code.Common.Entity;
using Entitas;

namespace Code.Gameplay.Input.System
{
    public class InitializeInputSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateInputEntity.Empty()
                .isInput = true;
        }
    }
}
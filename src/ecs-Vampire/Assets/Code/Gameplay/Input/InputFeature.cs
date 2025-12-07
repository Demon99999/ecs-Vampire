
using Code.Gameplay.Input.Service;
using Code.Gameplay.Input.System;
using Code.Infrastructure.Systems;
using Unity.VisualScripting;

namespace Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeInputSystem>());
            Add(systemFactory.Create<EmitInputSystem>());
        }
    }
}
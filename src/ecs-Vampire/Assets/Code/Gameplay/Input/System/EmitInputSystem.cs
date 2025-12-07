using System;
using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.System
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private IGroup<GameEntity> _inputs;

        public EmitInputSystem(GameContext gameContext, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = gameContext.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                if (_inputService.HasAxisInput())
                {
                    input.ReplaceAxisInput(new Vector2(_inputService.GetHorizontalAxis(), _inputService.GetVerticalAxis()));
                }
                else if(input.hasAxisInput)
                {
                    input.RemoveAxisInput();
                }
            }
        }
    }
}
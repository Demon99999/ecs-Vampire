using System;
using Code.Gameplay;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class EcsRuner : MonoBehaviour
    {
        private BattleFeature _battleFeature;
        private ISystemFactory _systemFactory;
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(ISystemFactory systemFactory, IStaticDataService staticDataService)
        {
            _systemFactory = systemFactory;
            _staticDataService = staticDataService;
        }

        private void Awake()
        {
            _staticDataService.LoadAll();
        }

        private void Start()
        {
            _battleFeature = _systemFactory.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        private void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _battleFeature.TearDown();
        }
    }
}
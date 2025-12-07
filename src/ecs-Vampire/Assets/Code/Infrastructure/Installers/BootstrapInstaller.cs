using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindInfrastructureServices();
            BindAssetManagementServices();
            BindCommonServices();
            BindSystemFactory();
            //BindUIFactories();
            BindContexts();
            //BindGameplayServices();
            //BindUIServices();
            BindCameraProvider();
            //BindGameplayFactories();
            BindEntityIndices();
            //BindStateMachine();
            //BindStateFactory();
            //BindGameStates();
            //BindProgressServices();
            
            BindEcsRunner();
        }

        private void BindSystemFactory()
        {
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        }

        private void BindEcsRunner()
        {
            // Способ 1: Создать новый GameObject с EcsRunner
            Container.BindInterfacesAndSelfTo<EcsRuner>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("EcsRunner")
                .AsSingle()
                .NonLazy();
        
            Debug.Log("EcsRunner will be created by Zenject");
        }
        
        private void BindEntityIndices()
        {
            //Container.BindInterfacesAndSelfTo<GameEntityIndices>().AsSingle();
        }
        
        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
      
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
        }
        
        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
        }
        
        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }
        
        private void BindCameraProvider()
        {
            Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
        }
        
        private void BindCommonServices()
        {
            Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
        
        private void BindInputService()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle().NonLazy();
        }

        public void Initialize()
        {
            //throw new System.NotImplementedException();
        }
    }
}
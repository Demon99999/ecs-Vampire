//using Code.Gameplay.Features.Abilities;
//using Code.Gameplay.Features.Abilities.Upgrade;

using System;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.System
{
  public class InitializeHeroSystem : IInitializeSystem
  {
    private readonly IHeroFactory _heroFactory;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IAbilityFactory _abilityFactory;
    
    //private readonly IAbilityUpgradeService _abilityUpgradeService;

    public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider, IAbilityFactory abilityFactory)
    {
      //_abilityUpgradeService = abilityUpgradeService;
      _heroFactory = heroFactory;
      _levelDataProvider = levelDataProvider;
      _abilityFactory = abilityFactory;
    }
    
    public void Initialize()
    {
      _heroFactory.CreateHero(_levelDataProvider.StartPoint);
      _abilityFactory.CreateVegetableBoltAbility(1);

      //_abilityUpgradeService.InitializeAbility(AbilityId.VegetableBolt);
    }
  }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 
/// </summary>
public class HeroTutorialTextUpdater : TutorialTextUpdater 
{

    #region Variable Declarations
    Hero hero;
    #endregion



    #region Unity Event Functions
    
    #endregion



    #region Protected Functions
    public override void UpdateText(PlayerConfig bossConfig)
    {
        hero = player.GetComponent<Hero>();

        if (colorChanges <= 1)
        {
            if (hero.PlayerConfig.Ability.Class == Ability.AbilityClass.Damage) ChangeTextTo("Damage");
            else if (hero.PlayerConfig.Ability.Class == Ability.AbilityClass.Tank) ChangeTextTo("Tank");
            else if (hero.PlayerConfig.Ability.Class == Ability.AbilityClass.Runner) ChangeTextTo("Opfer");
        }
        else if (colorChanges == 2)
        {
            ChangeTextTo("Switch");
        }
        else
        {
            // If same color as Boss
            if (bossConfig.ColorConfig == hero.PlayerConfig.ColorConfig)
            {
                if (hero.PlayerConfig.Ability.Class == Ability.AbilityClass.Damage) ChangeTextTo("DealDamage");
                else ChangeTextTo("GetDamage");
            }
            // Not Boss color
            else
            {
                if (hero.PlayerConfig.Ability.Class == Ability.AbilityClass.Damage) ChangeTextTo("PassDamage");
                else if (hero.PlayerConfig.Ability.Class == Ability.AbilityClass.Tank) ChangeTextTo("Tank");
                else if (hero.PlayerConfig.Ability.Class == Ability.AbilityClass.Runner) ChangeTextTo("Opfer");
            }
        }
    }
    #endregion
}

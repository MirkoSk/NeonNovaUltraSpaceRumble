﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// 
[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Tank/WobbleBobble")]
public class Tank_WobbleBobble : Ability
{

    #region Variable Declarations
    // Serialized Fields
    [Header("Ability Properties")]
    [SerializeField] float shieldDuration = 2f;

    // Private
    float shieldTimer = 0f;
    #endregion



    #region Public Properties

    #endregion



    #region Public Functions
    public override void Tick(float deltaTime, bool abilityButtonPressed)
    {
        if (!abilityActive)
        {
            base.Tick(deltaTime, abilityButtonPressed);
        }
        else
        {
            shieldTimer += deltaTime;

            if (shieldTimer >= shieldDuration)
            {
                DeactivateAbility();
            }
        }
    }

    public override void TriggerAbility()
    {
        hero.Shield.SetActive(true);
        hero.Rigidbody.mass = 100f;
        audioSource.PlayOneShot(soundClip, volume);

        abilityActive = true;
    }

    public override void DeactivateAbility()
    {
        hero.Shield.SetActive(false);
        hero.Rigidbody.mass = 1f;
        cooldownTimer = 0f;
        shieldTimer = 0f;
        abilityActive = false;
    }
    #endregion



    #region Private Functions

    #endregion
}


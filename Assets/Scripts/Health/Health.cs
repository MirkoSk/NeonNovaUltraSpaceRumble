﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 
/// </summary>
public class Health : MonoBehaviour
{

    #region Variable Declarations
    [SerializeField] protected int winningPointLead = 500;
    [SerializeField] protected bool endlessHealth;

    [SerializeField] protected GameEvent levelCompletedEvent = null;
    [SerializeField] protected GameEvent damageTakenEvent = null;

    protected int currentDamage;
    protected HealthbarUpdater healthbarUpdater;
    protected float timer;
    
    public int WinningPointLead { get { return winningPointLead; } set { winningPointLead = value; } }
    public int CurrentDamage { get { return currentDamage; } set { currentDamage = value; } }
    #endregion



    #region Unity Event Functions
    virtual protected void Start()
    {
        healthbarUpdater = GameObject.FindObjectOfType<HealthbarUpdater>();
        currentDamage = 0;
    }
    #endregion



    #region Public Functions
    virtual public void TakeDamage(int damage)
    {
        if (endlessHealth) return;

        currentDamage += damage;
    }
    #endregion
}

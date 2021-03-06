﻿#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class EditorLevelStarterNonLevel : EditorLevelStarter 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] SceneReference uI = null;
	// Private
	
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	
	#endregion
	
	
	
	#region Public Functions
	public override void Initialize()
    {
        if (!GameManager.Instance.IsInitialized && UnityEngine.SceneManagement.SceneManager.sceneCount <= 1)
        {
            SceneManager.Instance.LoadUIAdditive(uI);
        }
    }
	#endregion
	
	
	
	#region Private Functions
	
	#endregion
	
	
	
	#region GameEvent Raiser
	
	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}
#endif
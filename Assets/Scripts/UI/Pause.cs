﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Rewired;

public class Pause : MonoBehaviour
{
    

    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] GameObject mainMenu = null;
    [SerializeField] GameObject optionsMenu = null;
    [SerializeField] GameObject resumeButton = null;
    [SerializeField] EventSystem eventSystem = null;

    [Header("References")]
    [SerializeField] GameEvent gamePausedEvent = null;
    [SerializeField] GameEvent gameResumedEvent = null;

    bool gameIsPaused;

    List<InputHelper.PlayerRuleSet> playerRuleSets = new List<InputHelper.PlayerRuleSet>();



    public bool GameIsPaused { get { return gameIsPaused; } }



	// Use this for initialization
    private void Update()
    {
        if (gameIsPaused && !optionsMenu.activeSelf && InputHelper.GetButtonDown(RewiredConsts.Action.UICANCEL))
        {
            resumeButton.GetComponent<Button>().onClick.Invoke();
        }

        if (InputHelper.GetButtonDown(RewiredConsts.Action.PAUSE))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (gameIsPaused && !optionsMenu.activeSelf && InputHelper.GetButtonDown(RewiredConsts.Action.UICANCEL))
        {
            resumeButton.GetComponent<Button>().onClick.Invoke();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        playerRuleSets = InputHelper.ChangeRuleSetForAllPlayers(RewiredConsts.LayoutManagerRuleSet.RULESETMENU);

        pauseMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(resumeButton);

        gameIsPaused = true;

        RaiseGamePaused();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        InputHelper.ChangeRuleSetForPlayers(playerRuleSets);

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(null);

        gameIsPaused = false;

        RaiseGameResumed();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.Instance.LoadMainMenu();
    }

    public void ExitGame()
    {
        SceneManager.Instance.ExitGame();
    }

    private void RaiseGamePaused()
    {
        gamePausedEvent.Raise(this);
    }
    
    private void RaiseGameResumed()
    {
        gameResumedEvent.Raise(this);
    }
}

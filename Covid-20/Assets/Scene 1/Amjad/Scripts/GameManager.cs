﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm = null;

    PlayerController player;

    private void Awake()
    {
        // setup reference to game manager
        if (gm == null)
            gm = this.GetComponent<GameManager>();

        DontDestroyOnLoad(this); 
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0f)
            {
                UIManager.UIMgr.UIGamePaused.SetActive(true); // this brings up the pause UI
                Time.timeScale = 0f; // this pauses the game action
            }
            else
            {
                Time.timeScale = 1f; // this unpauses the game action (ie. back to normal)
                UIManager.UIMgr.UIGamePaused.SetActive(false); // remove the pause UI
            }
        }
    }

    #region Khalid 
    public void Lose()
    {
        UIManager.UIMgr.UILoseMessage.SetActive(true); // this brings up the pause UI
        Time.timeScale = 0f; // this pauses the game action
        Debug.Log("You Lost");
    }

    public void UpdateSLiderValue(float health)
    {
        UIManager.UIMgr.slider.value = health;
    }
    #endregion
}

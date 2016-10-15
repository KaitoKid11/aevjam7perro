﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    #region Singleton
    public static GameManager GameManagerInstance;
    public GameObject pauseMenu;

    void Awake()
    {
        if (GameManagerInstance == null)
            GameManagerInstance = gameObject.GetComponent<GameManager>();
    }
    #endregion

    public float score;
    public int lifes;

	// Use this for initialization
	void Start () {
        score = 0;
        lifes = 3;
        GUIManager.GUIManagerInstance.setInitialValues(lifes, score);
        PersistentScore.PersistentScoreInstance.Load();
        PersistentScore.PersistentScoreInstance.ResetScores();
        GUIManager.GUIManagerInstance.updateHighScore(PersistentScore.PersistentScoreInstance.scores);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(KeyCodes.Esc))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void increaseScore(float amount)
    {
        score += amount;
        GUIManager.GUIManagerInstance.updateScoreUI(score);
    }

    public void updateHP(bool dmg)
    {
        if (dmg)
        {
            --lifes;
            if(lifes == 0)
            {
                playerDead();
            }
            GUIManager.GUIManagerInstance.updateHealthUI(lifes);
        }
        else 
        {
            ++lifes;
            GUIManager.GUIManagerInstance.updateHealthUI(lifes);
        }
    }

    public void playerDead()
    {
        Debug.Log("FUCKING DEAD BIATCH");
        PersistentScore.PersistentScoreInstance.setFinalScore(score);
        SceneManager.LoadScene("MainMenu");
    }
}

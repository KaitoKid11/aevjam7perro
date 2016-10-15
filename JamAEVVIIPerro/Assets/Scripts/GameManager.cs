using UnityEngine;
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
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(KeyCodes.Esc))
        {
            pauseMenu.SetActive(false);
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
        //Application.LoadLevel("Puntuaciones");
    }
}

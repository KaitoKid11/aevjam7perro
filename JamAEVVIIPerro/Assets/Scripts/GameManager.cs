using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    #region Singleton
    public static GameManager GameManagerInstance;

    void Awake()
    {
        if (GameManagerInstance == null)
            GameManagerInstance = gameObject.GetComponent<GameManager>();
    }
    #endregion

    public float score;
    public int lifes = 1;
    public GameObject pauseMenu;


    public GameObject player;

    // Use this for initialization
    void Start () {
        score = 0;
        GUIManager.GUIManagerInstance.setInitialValues(lifes, score);
        PersistentScore.PersistentScoreInstance.Load();
        //PersistentScore.PersistentScoreInstance.ResetScores();
        GUIManager.GUIManagerInstance.updateHighScore(PersistentScore.PersistentScoreInstance.scores);

        this.GetComponent<AudioSource>().clip = SoundManager.SoundManagerInstance.getSoundTrack();
        this.GetComponent<AudioSource>().Play();

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
        //Debug.Log("FUCKING DEAD BIATCH");
        GUIManager.GUIManagerInstance.playerDead();
        player.GetComponent<CircleCollider2D>().enabled = false;
        //PersistentScore.PersistentScoreInstance.setFinalScore(score);
        //SceneManager.LoadScene("MainMenu");
    }
}

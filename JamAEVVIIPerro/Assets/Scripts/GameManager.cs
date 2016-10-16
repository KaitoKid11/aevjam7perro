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
    public int lifes = 3;
    
    [HideInInspector]
    public GameObject pauseMenu;

    private GameObject pauseMenuContainer;
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

        pauseMenuContainer = GameObject.FindGameObjectWithTag(Tags.PauseMenu);
        pauseMenu = pauseMenuContainer.transform.Find("PauseMenu").gameObject;


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

    public void viejaUsed()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(Tags.Enemy);
        GameObject[] balasEnemigas = GameObject.FindGameObjectsWithTag(Tags.EnemyBullet);
        GameObject[] boss = GameObject.FindGameObjectsWithTag(Tags.Boss);


        foreach (GameObject destroyable in balasEnemigas)
        {
            Destroy(destroyable);
        }
        foreach (GameObject destroyable in enemigos)
        {
            destroyable.GetComponent<EnemyLife>().Damage(5f);
        } 
        foreach (GameObject destroyable in boss)
        {
            //destroyable.GetComponent<BossHeadLife>().Damage(5f);
        }
        //Cambiar el valor de un atributo en el spawn de enemigos para bloquear el spawn de enemigos 2 segundos
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

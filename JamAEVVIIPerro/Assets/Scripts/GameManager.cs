using UnityEngine;
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
    //public int lifes;

	// Use this for initialization
	void Start () {
        score = 0;
        //lifes = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void increaseScore(float amount)
    {
        score += amount;
        GUIManager.GUIManagerInstance.updateScoreUI(score);
    }

    public void updateHP(float amount)
    {
        GUIManager.GUIManagerInstance.updateHealthUI(amount);
    }

    public void playerDead()
    {
        Debug.Log("FUCKING DEAD BIATCH");
        PersistentScore.PersistentScoreInstance.setFinalScore(score);
        //Application.LoadLevel("Puntuaciones");
    }
}

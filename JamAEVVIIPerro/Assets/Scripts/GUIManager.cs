using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {

    #region Singleton
    public static GUIManager GUIManagerInstance;

    void Awake()
    {
        if (GUIManagerInstance == null)
            GUIManagerInstance = gameObject.GetComponent<GUIManager>();
    }
    #endregion

    public Text healthText;
    public Text scoreText;


	public void updateHealthUI(float newHealth)
    {
        healthText.text = "" + newHealth;
    }


    public void updateScoreUI(float score)
    {
        scoreText.text = "" + score;
    }

}

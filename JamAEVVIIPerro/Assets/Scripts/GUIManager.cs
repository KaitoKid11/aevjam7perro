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

    public void updateHealthUI(int lifes)
    {
        healthText.text = "" + lifes;
    }

    public void updateScoreUI(float score)
    {
        scoreText.text = "" + score;
    }

    public void setInitialValues(int lifes, float score)
    {
        healthText.text = "" + lifes;
        scoreText.text = "" + score;
    }
}

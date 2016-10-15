using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

    [Header("HighScore")]
    public Text firstScoreNumber;
    public Text secondScoreNumber;
    public Text thirdScoreNumber;
    public Text fourthScoreNumber;
    public Text fifthScoreNumber;


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

    public void updateHighScore(List<Score> scores)
    {
        int count = scores.Count;
        firstScoreNumber.text = "";
        secondScoreNumber.text = "";
        thirdScoreNumber.text = "" ;
        fourthScoreNumber.text = "";
        fifthScoreNumber.text = "" ;

        if(count > 0)
            firstScoreNumber.text = "" + scores[0].name + " " + scores[0].score;
        if (count > 1)
            secondScoreNumber.text = "" + scores[1].name + " " + scores[1].score;
        if (count > 2)
            thirdScoreNumber.text = "" + scores[2].name + " " + scores[2].score;
        if (count > 3)
            fourthScoreNumber.text = "" + scores[3].name + " " + scores[3].score;
        if (count > 4)
            fifthScoreNumber.text = "" + scores[4].name + " " + scores[4].score;
 
    }

}

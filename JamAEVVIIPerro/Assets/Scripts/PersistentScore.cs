using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class PersistentScore : MonoBehaviour {

    #region Singleton
    public static PersistentScore PersistentScoreInstance;

    void Awake()
    {
        if (PersistentScoreInstance == null)
            PersistentScoreInstance = gameObject.GetComponent<PersistentScore>();
    }
    #endregion

    public float finalScore;
    List<Score> scores;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);

        //Load();
        //setFinalScore(10f);
	}

    public void setFinalScore(float score)
    {
        finalScore = score;
        
        Score newScore = new Score();
        newScore.score = score;
        newScore.name = "fff";

        if(scores == null)
            scores = new List<Score>();

        scores.Add(newScore);
        scores.Sort(CompareScoresByScore);
        Save();
        drawScores();
    }

    private static int CompareScoresByScore(Score score1, Score score2)
    {
        return score2.score.CompareTo(score1.score);
    }

    private void drawScores()
    {
        foreach(Score currentScore in scores)
        {
            Debug.Log(currentScore.name + " " + currentScore.score);

        }
    }
    public float getFinalScore(float score)
    {
        return finalScore;
    }

    private void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerScores data = new PlayerScores();
              
        data.scores = scores;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
            PlayerScores data = (PlayerScores)bf.Deserialize(file);
            file.Close();

            scores = data.scores;
        }
    }
    
}

[System.Serializable]
class PlayerScores
{
    public List<Score> scores;
}

[System.Serializable]
class Score
{
    public float score;
    public string name;
}
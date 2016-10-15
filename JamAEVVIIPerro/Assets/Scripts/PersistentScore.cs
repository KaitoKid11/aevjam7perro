using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
	}

    public void setFinalScore(float score)
    {
        finalScore = score;
    }

    public float getFinalScore(float score)
    {
        return finalScore;
    }

}

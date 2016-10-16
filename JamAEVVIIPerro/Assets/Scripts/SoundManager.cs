using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    #region Singleton
    public static SoundManager SoundManagerInstance;

    void Awake()
    {
        if (SoundManagerInstance == null)
            SoundManagerInstance = gameObject.GetComponent<SoundManager>();
    }
    #endregion

    public AudioClip soundtrack;
    public AudioClip explosion;
    public AudioClip EnemyDestroyed;
    public AudioClip[] playerShoot;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public AudioClip getSoundTrack()
    {
        return soundtrack;
    }

    public AudioClip getEnemyDestroyed()
    {
        return EnemyDestroyed;
    }


    public AudioClip getPlayerShoot()
    {
        return playerShoot[Random.Range(0,playerShoot.Length)];
    }

    public AudioClip getPlayerExplosion()
    {
        return explosion;
    }

}

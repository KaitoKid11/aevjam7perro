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
    public AudioClip[] playerShoot;

    private int playerShootController = 1;

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

    public AudioClip getPlayerShoot()
    {
        return playerShoot[Random.Range(0,playerShoot.Length)];
    }

}

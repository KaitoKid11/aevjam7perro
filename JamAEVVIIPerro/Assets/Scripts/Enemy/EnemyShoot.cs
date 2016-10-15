using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

    private GameObject enemyBullet;

    public GameObject EnemyBullet
    {
        get { return enemyBullet; }
        set { enemyBullet = value; }
    }

    [Header("Bullets")]
    public int numBullets = 3;
    public float shootingCooldown = 1.5f;

    void Start()
    {
        StartCoroutine(Shooting());
    }

	void Update ()
    {
	}

    // Shooting coroutine
    IEnumerator Shooting()
    {
        while (true)
        {
            // Waiting...
            yield return new WaitForSeconds(shootingCooldown);

            // Instantiating bullets...
            Instantiate(EnemyBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Instantiate(EnemyBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Instantiate(EnemyBullet, transform.position, Quaternion.identity);
        }
    }

}

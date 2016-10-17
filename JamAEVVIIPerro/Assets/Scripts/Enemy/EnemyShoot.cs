using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

    public GameObject enemyBullet;

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
        if (EnemyBullet == null)
            EnemyBullet = EnemyManager.enemyManagerInstance.enemyBullet;

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
            // Instantiating bullets...
            for (int i = 0; i < numBullets; ++i )
            {
                InstantiateBullet(EnemyBullet, transform.position);
                yield return new WaitForSeconds(0.25f);
            }

            // Waiting...
            yield return new WaitForSeconds(shootingCooldown);
        }
    }

    private void InstantiateBullet(GameObject bulletGameObject, Vector3 bulletPosition)
    {
        GameObject newEnemyInstance = (GameObject)Instantiate(bulletGameObject, bulletPosition, Quaternion.identity);

        if (bulletGameObject == EnemyManager.enemyManagerInstance.enemyHunter)
            newEnemyInstance.AddComponent<EnemyMoveFollow>();
    }

}

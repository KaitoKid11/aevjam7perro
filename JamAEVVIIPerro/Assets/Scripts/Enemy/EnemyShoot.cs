using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

    private bool m_invulnerability = false;
    private GameObject enemyBullet;

    public GameObject EnemyBullet
    {
        get { return enemyBullet; }
        set { enemyBullet = value; }
    }

    public float m_shootingCooldown = 1f;

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
            yield return new WaitForSeconds(m_shootingCooldown);

            // Instantiating bullet...
            Instantiate(EnemyBullet, transform.position, Quaternion.identity);
        }
    }

}

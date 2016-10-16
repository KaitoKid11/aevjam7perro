using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

    // Salud del enemigo
    public float health = 1.0f;
    public float enemyScore = 100f;

	void Start ()
    {
	}
	
	void Update ()
    {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == Tags.PlayerBullet)
        {
            if (other.gameObject.GetComponent<ForwardBullet>() != null)
                Damage(other.gameObject.GetComponent<ForwardBullet>().damage);
            else
                Damage(other.gameObject.GetComponent<ConeBullet>().damage);

            GameManager.GameManagerInstance.increaseScore(enemyScore);
        }
    }

    // Llamada cuando el enemigo recibe daño
    void Damage(float damage)
    {
        // Recibe el daño
        health -= damage;

        // Comprueba
        if (health <= 0.0f)
        {
            DropManager.DropManagerInstance.basicEnemyDrop(this.transform.position);
            Destroy(this.gameObject);
        }
    }
}

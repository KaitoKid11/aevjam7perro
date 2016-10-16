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
            GameManager.GameManagerInstance.increaseScore(enemyScore);

            if(GetComponent<EnemyShoot>() != null)
                GetComponent<EnemyShoot>().enabled = false;

            GetComponent<Animator>().SetTrigger("Destroy");
            GetComponent<CircleCollider2D>().enabled = false;

            this.GetComponent<AudioSource>().clip = SoundManager.SoundManagerInstance.getEnemyDestroyed();
            this.GetComponent<AudioSource>().Play();
        }
    }

    public void EnemyDestroyedAnimEnd()
    {
        Destroy(this.gameObject);
        
    }
}


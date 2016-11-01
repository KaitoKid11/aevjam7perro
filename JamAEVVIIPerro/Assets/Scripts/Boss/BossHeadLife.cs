using UnityEngine;
using System.Collections;

public class BossHeadLife : MonoBehaviour {

    // Salud
    public float health = 10.0f;
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

            Destroy(other.gameObject);
        }
    }

    // Llamada cuando el enemigo recibe daño
    public void Damage(float damage)
    {
        if (transform.parent.GetComponent<BossLogic>().Invulnerable == true)
            return;

        // Recibe el daño
        health -= damage;
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(restoreColor());

        // Comprueba
        if (health <= 0.0f)
        {
            GameManager.GameManagerInstance.increaseScore(enemyScore);
            Destroy(this.gameObject);
            transform.parent.GetComponent<BossLogic>().HeadDestroyed();
        }
    }

    IEnumerator restoreColor()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}

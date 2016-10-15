using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

    // Salud del enemigo
    public float health = 1.0f;

	void Start ()
    {
	}
	
	void Update ()
    {
	}

    void OnCollisionEnter(Collision collision)
    {
    }

    // Llamada cuando el enemigo recibe daño
    void Damage(float damage)
    {
        // Recibe el daño
        health -= damage;

        // Comprueba
        if (health <= 0.0f)
            Destroy(this.gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    private float m_timeSinceLastAttack;
    private bool m_invulnerability = false;
    private int m_attackLevel = 1;

    [Header("Bullets")]
    public GameObject currentBasicBullet;
    public float m_shootingCooldown = 1f;
    public int maxLevel = 3;

    /*
    [Header("Health")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;
	*/
	// Update is called once per frame
	void Update () {

        if (Input.GetButton(KeyCodes.Fire1) && m_timeSinceLastAttack < 0)
        {
            m_timeSinceLastAttack = m_shootingCooldown;
            Instantiate(currentBasicBullet, transform.position, Quaternion.identity);
            
        }
        m_timeSinceLastAttack -= Time.deltaTime;
	}

    public void receiveDamage()
    {
        //Empezar corrutina explosión
        updateAttack(false);
        GameManager.GameManagerInstance.updateHP(true);
    }

    public void receiveHealth()
    {
        GameManager.GameManagerInstance.updateHP(false);
    }

    public void updateAttack(bool dmg)
    {
        if (dmg)
            m_attackLevel = 0;
        else
            if (m_attackLevel < maxLevel)
                ++m_attackLevel;
            else
                m_attackLevel = maxLevel;
    }

    public void death()
    {
        //Espera hasta que la animación de destrucción acabe - Introducir aquí
        GameManager.GameManagerInstance.playerDead();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!m_invulnerability) { 
            if (other.tag == Tags.BalaEnemiga || other.tag == Tags.Enemigo)
            {
                receiveDamage();
            }

        }

        if (other.tag == Tags.LifeUp)
        {
            receiveHealth();
        }

        if (other.tag == Tags.PowerUp)
        { 
            //Cambio patrón ataque`+ mayor velocidad de disparo
        }
    }
}

using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    private float m_timeSinceLastAttack;
    private bool m_invulnerability = false;
    private float m_timeInvulnerability;

    [Header("Config. Player")]
    public int m_attackLevel = 1;
    public float m_timeInvulnerabilityBase = 1f;

    [Header("Bullets")]
    public GameObject currentBasicBullet;
    public GameObject leftConeBullet;
    public GameObject RightConeBullet;
    public float m_shootingCooldown = 1f;
    public int maxLevel = 3;

    private bool playerHasRevived = true;

	void Update () {

        //Actualmente la invulnerabilidad es solo para cuando has muerto ergo limita las acciones del player.
        if (Input.GetButton(KeyCodes.Fire1) && m_timeSinceLastAttack < 0 && !playerHasRevived)
        {
            shoot(m_attackLevel);
        }

        m_timeSinceLastAttack -= Time.deltaTime;
        m_timeInvulnerability -= Time.deltaTime;

        if (m_invulnerability && m_timeInvulnerability < 0)
        {
            m_invulnerability = false;
        }
        if (playerHasRevived)
        {
            playerHasRevived = false;
            GetComponent<Animator>().SetTrigger("PlayerRevive");
            transform.position = new Vector3(0f, -4f, 0f);
            this.GetComponent<PlayerMovement>().dead(false);
        }
	}

    public void receiveDamage()
    {
        //Empezar corrutina explosión

        //Valor a true indica muerte ergo volver a 1, bloquear movimiento y encender invulnerabilidad


        GetComponent<Animator>().SetTrigger("PlayerDeath");
        m_invulnerability = true;
        m_timeInvulnerability = m_timeInvulnerabilityBase;
        this.GetComponent<PlayerMovement>().dead(true);
        updateAttack(true);
        GameManager.GameManagerInstance.updateHP(true);
    }

    public void receiveHealth()
    {
        GameManager.GameManagerInstance.updateHP(false);
    }

    public void updateAttack(bool dmg)
    {
        if (dmg)
            m_attackLevel = 1;
        else
            if (m_attackLevel < maxLevel)
                ++m_attackLevel;
            else
                m_attackLevel = maxLevel;
    }

    public void revivingAnimationEnded()
    {
        playerHasRevived = true;
    }

    public void death()
    {
        //Espera hasta que la animación de destrucción acabe - Introducir aquí
        GameManager.GameManagerInstance.playerDead();
    }

    public void shoot(int level)
    {
        Vector3 player = this.transform.position;
        Vector3 playerLeft = new Vector3(player.x - 0.3f, player.y, player.z);
        Vector3 playerRight = new Vector3(player.x + 0.3f, player.y, player.z);

        this.GetComponent<AudioSource>().clip = SoundManager.SoundManagerInstance.getPlayerShoot();
        this.GetComponent<AudioSource>().Play();

        switch (level)
        {
            case 1:
                m_timeSinceLastAttack = m_shootingCooldown;
                Instantiate(currentBasicBullet, player, Quaternion.identity);
                break;
            case 2:
                m_timeSinceLastAttack = m_shootingCooldown;
                Instantiate(currentBasicBullet, playerLeft, Quaternion.identity);
                Instantiate(currentBasicBullet, playerRight, Quaternion.identity);
                break;
            case 3:
                m_timeSinceLastAttack = m_shootingCooldown;
                Instantiate(currentBasicBullet, playerLeft, Quaternion.identity);
                Instantiate(currentBasicBullet, playerRight, Quaternion.identity);
                Instantiate(leftConeBullet, playerLeft, Quaternion.identity);
                Instantiate(RightConeBullet, playerRight, Quaternion.identity);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!m_invulnerability) { 
            if (other.tag == Tags.EnemyBullet || other.tag == Tags.Enemy)
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
            //Valor a false indica mejora
            updateAttack(false);
        }
    }
}

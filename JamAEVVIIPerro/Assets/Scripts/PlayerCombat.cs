using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    private float m_timeSinceLastAttack;

    [Header("Bullets")]
    public GameObject currentBasicBullet;
    public float m_shootingCooldown = 1f;

    [Header("Health")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton(KeyCodes.Fire1) && m_timeSinceLastAttack < 0)
        {
            m_timeSinceLastAttack = m_shootingCooldown;
            Instantiate(currentBasicBullet, transform.position, Quaternion.identity);
            
        }
        m_timeSinceLastAttack -= Time.deltaTime;
	}

    public void receiveDamage(float amount)
    {
        currentHealth -= amount;
        
        if(currentHealth <= 0)
        {
            currentHealth = 0f;
            death();
        }
        GUIManager.GUIManagerInstance.updateHealthUI(amount);

    }

    public void receiveHealth(float amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        GUIManager.GUIManagerInstance.updateHealthUI(amount);


    }


    public void death()
    {
        Debug.Log("has muerto");
    }
}

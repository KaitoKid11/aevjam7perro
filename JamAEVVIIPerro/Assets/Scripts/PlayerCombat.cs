using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    public GameObject currentBasicBullet;
    private float m_timeSinceLastAttack;
    public float m_shootingCooldown = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton(KeyCodes.Fire1) && m_timeSinceLastAttack < 0)
        {
            m_timeSinceLastAttack = m_shootingCooldown;
            Instantiate(currentBasicBullet, transform.position, Quaternion.identity);
            
        }
        m_timeSinceLastAttack -= Time.deltaTime;
	}
}

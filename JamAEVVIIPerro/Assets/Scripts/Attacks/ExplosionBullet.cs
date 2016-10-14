using UnityEngine;
using System.Collections;

public class ExplosionBullet : MonoBehaviour {


    public float bulletSpeed = 6f;
    public float damage = 50f;

    
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, Time.deltaTime * bulletSpeed, 0);
	

	}
}

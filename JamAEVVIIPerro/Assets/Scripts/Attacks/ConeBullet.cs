using UnityEngine;
using System.Collections;

public class ConeBullet : MonoBehaviour {

    public float bulletSpeed = 6f;
    public float damage = 10f;
    public bool left;
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = this.transform.position;

        if(left)
            transform.Translate((Time.deltaTime * bulletSpeed) * -(bulletSpeed/20), Time.deltaTime * bulletSpeed * 1.5f, 0);
        else
            transform.Translate((Time.deltaTime * bulletSpeed) * bulletSpeed/20, Time.deltaTime * bulletSpeed * 1.5f, 0);
	}
}

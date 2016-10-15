using UnityEngine;
using System.Collections;

public class ForwardBullet : MonoBehaviour {

    public float bulletSpeed = 6f;
    public float damage = 10f;

	// Update is called once per frame
	void Update () {
        transform.Translate(0, Time.deltaTime * bulletSpeed, 0);
	}
}

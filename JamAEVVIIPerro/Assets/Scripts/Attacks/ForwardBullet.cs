using UnityEngine;
using System.Collections;

public class ForwardBullet : MonoBehaviour {


    public float bulletSpeed = 6f;
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0, Time.deltaTime * bulletSpeed, 0);

	}
}

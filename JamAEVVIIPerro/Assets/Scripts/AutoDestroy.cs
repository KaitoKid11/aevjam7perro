using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

    [Tooltip("Seconds until is destroyed")]
    public float secToDestroy = 5f;

	void Start () {
        Destroy(gameObject, secToDestroy);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Enemy && this.tag != Tags.EnemyBullet)
        {
            Destroy(this.gameObject);
        }
    }
	
}

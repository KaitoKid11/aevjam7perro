using UnityEngine;
using System.Collections;

public class ExplosionBullet : MonoBehaviour {


    public float bulletSpeed = 6f;
    public float damage = 50f;

    private Vector2 destination = Vector2.zero;
    
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(transform.position, destination);
        float time = 0.3f;
        float speed = distance / time;
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, destination) < 0.1f)
        {
            GameManager.GameManagerInstance.viejaUsed();
            Destroy(gameObject);
        }
        /*transform.position = Vector2.MoveTowards(transform.position, destination, bulletSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, destination) < 0.1f)
        {
            Destroy(gameObject);
        }*/   
	}
}

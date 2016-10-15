using UnityEngine;
using System.Collections;

public class EnemyMoveStraight : MonoBehaviour {

    public float speed = 2.5f;

	void Start () {
	
	}
	
	void Update () {
        Vector3 enemyPosition = transform.position;
        enemyPosition.y -= speed * Time.deltaTime;
        transform.position = enemyPosition;
	}
}

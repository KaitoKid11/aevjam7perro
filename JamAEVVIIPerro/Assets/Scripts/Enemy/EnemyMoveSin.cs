using UnityEngine;
using System.Collections;

public class EnemyMoveSin : MonoBehaviour {

    public float speed = 2.5f;
    public float sinCurveFactor = Random.Range(-1.5f, 1.5f);

	void Start () {
	
	}
	
	void Update () {
        Vector3 enemyPosition = transform.position;
        enemyPosition.x += Mathf.Sin(Time.time) * Time.deltaTime * sinCurveFactor; 
        enemyPosition.y -= speed * Time.deltaTime;
        transform.position = enemyPosition;
	}
}

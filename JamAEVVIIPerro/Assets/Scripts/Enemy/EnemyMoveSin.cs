using UnityEngine;
using System.Collections;

public class EnemyMoveSin : MonoBehaviour {

    public float speed = 4.5f;
    public float sinCurveFactor = Random.Range(-1.5f, 1.5f);

	void Start () {
	
	}
	
	void Update () {
        transform.Translate(Mathf.Sin(Time.time) * sinCurveFactor * Time.deltaTime, -speed * Time.deltaTime, 0.0f);
	}
}

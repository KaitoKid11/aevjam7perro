using UnityEngine;
using System.Collections;

public class EnemyMoveStraight : MonoBehaviour {

    public float speed = 4.5f;

	void Start () {
	
	}
	
	void Update () {
        transform.Translate(0.0f, - speed * Time.deltaTime, 0.0f);
	}
}

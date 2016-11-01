using UnityEngine;
using System.Collections;

public class EnemyMoveStraight : MonoBehaviour {

    public float speed = 2.5f;

	void Start () {
	
	}
	
	void Update () {
        transform.Translate(0.0f, - speed * Time.deltaTime, 0.0f);
	}

    public void increaseDifficulty()
    {
        if(speed < 4f)
            speed = speed + 0.5f;
    }
}

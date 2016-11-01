using UnityEngine;
using System.Collections;

public class EnemyMoveFollow : MonoBehaviour
{
    private GameObject player;

    public float speed = 3.5f;

	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
	}
	
	void Update () {
        Vector3 directionVector = player.transform.position - transform.position;
        directionVector.Normalize();

        transform.Translate(directionVector * speed * Time.deltaTime);
	}

    public void increaseDifficulty()
    {
        if(speed < 5)
            speed = speed + 0.5f;
    }
}

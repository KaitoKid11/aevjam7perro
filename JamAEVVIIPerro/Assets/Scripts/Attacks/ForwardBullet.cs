using UnityEngine;
using System.Collections;

public class ForwardBullet : MonoBehaviour {

    public enum Direction
    {
        Top = 1,
        Bottom = -1
    }

    public Direction bulletDirection = Direction.Top;
    public float bulletSpeed = 6f;
    public float damage = 10f;

	// Update is called once per frame
	void Update () {
        transform.Translate(0, Time.deltaTime * bulletSpeed * (int)bulletDirection, 0);
	}
}

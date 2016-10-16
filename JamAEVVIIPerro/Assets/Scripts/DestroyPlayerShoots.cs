using UnityEngine;
using System.Collections;

public class DestroyPlayerShoots : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.PlayerBullet)
        {
            Destroy(other.gameObject);
        }
    }

}

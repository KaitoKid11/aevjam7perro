using UnityEngine;
using System.Collections;

public class LifeDrop : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Player)
        {
            other.gameObject.GetComponent<PlayerCombat>().receiveHealth();
            Destroy(this.gameObject);
        }
    }

}

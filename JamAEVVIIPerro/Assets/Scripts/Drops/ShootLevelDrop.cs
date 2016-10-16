﻿using UnityEngine;
using System.Collections;

public class ShootLevelDrop : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Player)
        {
            other.gameObject.GetComponent<PlayerCombat>().updateAttack(false);
            Destroy(this.gameObject);
        }
    }

}

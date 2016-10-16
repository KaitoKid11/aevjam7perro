﻿using UnityEngine;
using System.Collections;

public class LifeDrop : MonoBehaviour {

    void OnEnable()
    {
        StartCoroutine(autoDestroy());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Player)
        {
            other.gameObject.GetComponent<PlayerCombat>().receiveHealth();
            Destroy(this.gameObject);
        }
    }

    IEnumerator autoDestroy()
    {
        yield return new WaitForSeconds(DropManager.DropManagerInstance.timeToDestroy);
        Destroy(this.gameObject);
    }

}

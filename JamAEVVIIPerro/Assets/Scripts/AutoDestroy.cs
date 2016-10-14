using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {


    [Tooltip("Seconds until is destroyed")]
    public float secToDestroy = 4f;

	void Start () {
        Destroy(gameObject, secToDestroy);
	}
	
}

using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

    public float movement = 0.03f;

	// Update is called once per frame
	void Update () {
        Vector3 pos = this.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y - movement, pos.z);
	}
}

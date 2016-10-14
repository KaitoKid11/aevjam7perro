using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 pos = this.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y - 0.03f, pos.z);
	}
}

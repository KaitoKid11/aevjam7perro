using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

    public float movement = 5000.0f;

	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(0, -50, 0);
        this.transform.Translate(pos * movement * Time.deltaTime);
        //this.transform.position = new Vector3(pos.x, pos.y - movement , pos.z);
	}
}

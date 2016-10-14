using UnityEngine;
using System.Collections;

public class SpawnBlock : MonoBehaviour {

    public Transform[] spawns = new Transform[7];
    public GameObject bloque;

    private GameObject x;
	// Use this for initialization
	void Start () {
        x = (GameObject)Instantiate(bloque, spawns[0].position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = x.transform.position;
        x.transform.position = new Vector3(pos.x, pos.y - 0.01f, pos.z);
	}

    void SpawnBlock()
    {

    }
}

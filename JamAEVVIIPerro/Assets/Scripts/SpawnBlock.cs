using UnityEngine;
using System.Collections;

public class SpawnBlock : MonoBehaviour {

    public GameObject bloque;
    public Sprite[] sprites = new Sprite[4];

	// Use this for initialization
	void Start () {
        for (int i = 1; i < 8; ++i)
        {
            bloque.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            Instantiate(bloque, transform.FindChild("Building" + i + "/Spawn").transform.position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SpawnBlockUnit(Transform spawn)
    {
        bloque.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        Instantiate(bloque, spawn.position, Quaternion.identity);
    }

    public void DeleteBlockUnit(Collider2D bloque)
    {
        Destroy(bloque.gameObject);
    }
}

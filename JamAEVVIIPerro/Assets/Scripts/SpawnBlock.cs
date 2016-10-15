using UnityEngine;
using System.Collections;

public class SpawnBlock : MonoBehaviour {

    public GameObject bloque;
    public Sprite[] spritesBasicos = new Sprite[7];
    public Sprite[] spritesLargos = new Sprite[1];

    private int[] lastUsed = new int[7];
	// Use this for initialization
	void Start () {
        for (int i = 1; i < 8; ++i)
        {
            int sprite = Random.Range(0, spritesBasicos.Length);
            bloque.GetComponent<SpriteRenderer>().sprite = spritesBasicos[sprite];
            Instantiate(bloque, transform.FindChild("Building" + i + "/Spawn").transform.position, Quaternion.identity);
            lastUsed[i-1] = sprite; 
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SpawnBlockUnit(Transform spawn, int index)
    {
        if (lastUsed[index] == 6)
        {
            bloque.GetComponent<SpriteRenderer>().sprite = spritesLargos[0];
            Instantiate(bloque, spawn.position, Quaternion.identity);
            lastUsed[index] = 0;
        }
        else
        {
            int sprite = Random.Range(0, spritesBasicos.Length);
            bloque.GetComponent<SpriteRenderer>().sprite = spritesBasicos[sprite];
            Instantiate(bloque, spawn.position, Quaternion.identity);
            lastUsed[index] = sprite;
        }
    }

    public void DeleteBlockUnit(Collider2D bloque)
    {
        Destroy(bloque.gameObject);
    }
}

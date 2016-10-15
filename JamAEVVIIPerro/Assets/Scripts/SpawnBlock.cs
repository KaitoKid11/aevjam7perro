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
            if(i != 1 && i != 7)
            {
                if(lastUsed[i-1] == 999/*Valor de carretera o río en giro*/)
                {
                    //COLOCAR LOS CUADROS CONTIGUOS A CARRETERA O RÍO en giro
                }
                else
                {
                    //SOLO COLOCAR LOS QUE QUEREMOS EN LOS BORDES
                    int sprite = Random.Range(0, spritesBasicos.Length);
                    bloque.GetComponent<SpriteRenderer>().sprite = spritesBasicos[sprite];
                    Instantiate(bloque, transform.FindChild("Building" + i + "/Spawn").transform.position, Quaternion.identity);
                    lastUsed[i - 1] = sprite;
                }
            }
            else
            { 
                int sprite = Random.Range(0, spritesBasicos.Length);
                bloque.GetComponent<SpriteRenderer>().sprite = spritesBasicos[sprite];
                Instantiate(bloque, transform.FindChild("Building" + i + "/Spawn").transform.position, Quaternion.identity);
                lastUsed[i-1] = sprite;
            }
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
        else if(lastUsed[index] == 999/*CARRETERA O RÍO*/)
        {
            /*PUEDE SEGUIR RECTO O GIRAR*/
            if(false /*GIRAR*/)
            {
                if(index == 0)
                {
                    /*SOLO PUEDE GIRAR A DERECHA*/
                }
                else if(index == 6)
                {
                    /*SOLO PUEDE GIRAR A IZQUIERDA*/
                }
                else
                {
                    /*PUEDE GIRAR A AMBOS LADOS*/
                }
            }
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

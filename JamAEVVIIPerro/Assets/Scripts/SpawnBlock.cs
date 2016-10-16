using UnityEngine;
using System.Collections;

public class SpawnBlock : MonoBehaviour {

    public GameObject bloque;

    public Sprite[] spritesBasicos = new Sprite[7];     //Índice 1 - Indica edificios normales
    public Sprite[] rioRecto = new Sprite[9];           //Índice 2 - Indica partes del río rectas
    public Sprite[] rioCurva = new Sprite[6];           //Índice 3 - Indica partes del río rectas
    public Sprite[] spritesLargos = new Sprite[1];      //Índice 4 - Indica edificios normales largos

    private int[][] lastUsed = new int[7][];
    private bool giro;
    private int contSpawned = 0;

	void Start () {
        for (int i = 0; i < lastUsed.Length; ++i)
            lastUsed[i] = new int[2];

        //[i - 1] -> Soy yo 
        for (int i = 1; i < 8; ++i) //Recorremos los spawns de bloques
        {
            //El río siempre empieza en 3
            if(i == 3)
            {
                int sprite = 0;
                bloque.GetComponent<SpriteRenderer>().sprite = rioRecto[sprite];
                Instantiate(bloque, transform.FindChild("Building" + i + "/Spawn").transform.position, Quaternion.identity);
                ++contSpawned;

                lastUsed[i - 1][0] = 2;
                lastUsed[i - 1][1] = sprite;
            }
            else
            {
                int sprite;
                if (i > 2 && lastUsed[i - 2][0] == 2 && i < 6)
                {
                    sprite = lastUsed[i - 2][1] + 3;
                    bloque.GetComponent<SpriteRenderer>().sprite = rioRecto[sprite];
                    lastUsed[i - 1][0] = 2;
                }
                else
                {
                    sprite = Random.Range(0, spritesBasicos.Length);
                    bloque.GetComponent<SpriteRenderer>().sprite = spritesBasicos[sprite];
                    lastUsed[i - 1][0] = 1;
                }
                Instantiate(bloque, transform.FindChild("Building" + i + "/Spawn").transform.position, Quaternion.identity);
                ++contSpawned;
                
                lastUsed[i - 1][1] = sprite;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(contSpawned == 7)
        {
            giro = false;
            contSpawned = 0;
        }
	}

    public void SpawnBlockUnit(Transform spawn, int index)
    {
        int sprite;
        int[] rectosRio = {0, 3, 6};
        if(index == 2)
        {
            int x = 0;
        }
        //Los index van desde 0 (Spawn más a la izq) hasta 6 (spawn) más a la derecha
        //Continuación de edificio largo
        if (lastUsed[index][0] == 1 && lastUsed[index][1] == 6)
        {
            bloque.GetComponent<SpriteRenderer>().sprite = spritesLargos[0];
            Instantiate(bloque, spawn.position, Quaternion.identity);
            ++contSpawned;
            
            lastUsed[index][0] = 4;
            lastUsed[index][1] = 0;
        }
        //Continuación de río si eres el primero colocado (Giro o no)
        else if(lastUsed[index][0] == 2 && lastUsed[index][1] < 3)
        {
            Debug.Log("Entrada.");
            Debug.Log("Index 0: " + lastUsed[index][0]);
            Debug.Log("Index 1: " + lastUsed[index][1]);
            int giroRand = Random.Range(0, 2);
            //Sigue recto
            if(true)//giroRand == 0)
            {
                sprite = Random.Range(1, rioRecto.Length + 1);
                bloque.GetComponent<SpriteRenderer>().sprite = rioRecto[sprite % 3];

                lastUsed[index][0] = 2;
                lastUsed[index][1] = sprite;
            }
            else
            {
                if (index == 0)
                {
                    /*SOLO PUEDE GIRAR A DERECHA*/
                }
                else if (index == 6)
                {
                    /*SOLO PUEDE GIRAR A IZQUIERDA*/
                }
                else
                {
                    /*PUEDE GIRAR A AMBOS LADOS*/
                }
            }

            Instantiate(bloque, spawn.position, Quaternion.identity);
            ++contSpawned;
        }
        //Río sin ser el primero colocado
        else if(lastUsed[index][0] == 2 && (lastUsed[index][1]+1)%3 != 1)
        {

        }
        else
        {
            sprite = Random.Range(0, spritesBasicos.Length);
            bloque.GetComponent<SpriteRenderer>().sprite = spritesBasicos[sprite];
            Instantiate(bloque, spawn.position, Quaternion.identity);
            ++contSpawned;

            lastUsed[index][0] = 0;
            lastUsed[index][1] = sprite;
        }
    }

    public void DeleteBlockUnit(Collider2D bloque)
    {
        Destroy(bloque.gameObject);
    }
}

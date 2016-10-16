using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour
{
    // Altura en la que debe estabilizarse
    private float Y_POS = 3.0f;

    // Player
    private GameObject player;

    // Entrando en la escena
    private bool gettingIn = true;

    // Velocidad
    public float speed = 2.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
	}
	
    void Update()
    {
        if (gettingIn)
        {
            // Todavía está entrando en la escena
            transform.Translate(0.0f, -1.0f * speed * Time.deltaTime, 0.0f);
            
            if (transform.position.y <= Y_POS)
            {
                gettingIn = false;
                gameObject.GetComponent<BossLogic>().Activate();
            }
        }
        else
        {
            Vector3 directionVector = player.transform.position - transform.position;
            directionVector.Normalize();

            transform.Translate(directionVector.x * speed * Time.deltaTime, 0.0f, 0.0f);
        }
	}
}

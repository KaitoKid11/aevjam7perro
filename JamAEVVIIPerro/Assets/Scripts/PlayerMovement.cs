using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


    public float m_playerSpeed = 5;

	void Start () {
	
	}
	
	void Update () {


        if (Input.GetButton(KeyCodes.Up))
        {
            transform.Translate(0, Time.deltaTime * m_playerSpeed, 0);

        }

        if (Input.GetButton(KeyCodes.Down))
        {
            transform.Translate(0, Time.deltaTime * -m_playerSpeed, 0);

        }

        if (Input.GetButton(KeyCodes.Left))
        {
            transform.Translate(Time.deltaTime * -m_playerSpeed, 0, 0);

        }

        if (Input.GetButton(KeyCodes.Right))
        {
            transform.Translate(Time.deltaTime * m_playerSpeed, 0, 0);

        }
	}
}

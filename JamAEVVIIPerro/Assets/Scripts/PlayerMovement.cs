using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


    public float m_playerSpeed = 5;

    [Header("Borders")]
    public float minX = -7f;
    public float maxX = 6.56f;

    public float minY = -4.64f;
    public float maxY = 4.42f;
	void Update () {


        if (Input.GetButton(KeyCodes.Up) && transform.position.y < maxY)
        {
            transform.Translate(0, Time.deltaTime * m_playerSpeed, 0);

        }

        if (Input.GetButton(KeyCodes.Down) && transform.position.y > minY)
        {
            transform.Translate(0, Time.deltaTime * -m_playerSpeed, 0);

        }

        if (Input.GetButton(KeyCodes.Left) && transform.position.x > minX)
        {
            transform.Translate(Time.deltaTime * -m_playerSpeed, 0, 0);

        }

        if (Input.GetButton(KeyCodes.Right) && transform.position.x < maxX)
        {
            transform.Translate(Time.deltaTime * m_playerSpeed, 0, 0);

        }
	}
}

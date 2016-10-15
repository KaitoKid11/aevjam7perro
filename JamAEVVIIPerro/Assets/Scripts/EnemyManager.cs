using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    // Tipos de movimiento de los enemigos
    private enum MovementType
    {
        Straight,
        Sin
    }

    // Tipos de ataque de los enemigos
    private enum AttackType
    {
        Shoot
    }

    // Márgenes del mapa de juego
    private float X_MIN = -7.0f;
    private float X_MAX = 7.0f;

    private float Y_MIN = -8.0f;
    private float Y_MAX = 8.0f;
    
    // Tiempo de espera entre enemigos
    public float waitingTime = 1.0f;

    // Prefab del enemigo
    public GameObject enemy;
    
    // Proyectiles
    public GameObject enemyBullet;

    #region Singleton
    public static EnemyManager enemyManagerInstance;

    void Awake()
    {
        if (enemyManagerInstance == null)
            enemyManagerInstance = gameObject.GetComponent<EnemyManager>();
    }
    #endregion

    void Start()
    {
        StartCoroutine(GenerateEnemies());
	}
	
	void Update () {
	}

    // Enemy generation coroutine
    IEnumerator GenerateEnemies()
    {
        while (true)
        {
            // Waiting...
            yield return new WaitForSeconds(waitingTime);

            // Instantiating enemies...
            InstantiateThreeEnemies();
        }
    }

    // Instancia un único enemigo en una posición aleatoria del mapa
    void InstantiateOneEnemy()
    {
        // Tipo de movimiento del enemigo
        MovementType movementType = GetMovementType();

        // Posición del enemigo
        float xRndPosition = Random.Range(X_MIN, X_MAX);
        Vector3 newEnemyPosition = new Vector3(xRndPosition, Y_MAX + 1.0f, 0.0f);

        // Creación del enemigo
        InstantiateEnemy(enemy, newEnemyPosition, Quaternion.identity, movementType);
    }

    // Instancia tres enemigos en posiciones aleatorias del mapa, pero
    // simétricas con respecto al centro
    void InstantiateThreeEnemies()
    {
        // Tipo de movimiento de los enemigos
        MovementType movementType = GetMovementType();

        // Desplazamiento con respecto al centro del mapa
        float xRndShift = Random.Range(X_MIN, X_MAX);
        float xCenterPosition = X_MIN + (X_MAX - X_MIN) / 2;

        Vector3 centerEnemyPosition = new Vector3(xCenterPosition, Y_MAX + 1.0f, 0.0f);

        // Creación de los enemigos
        InstantiateEnemy(enemy, centerEnemyPosition, Quaternion.identity, movementType);
        InstantiateEnemy(enemy, centerEnemyPosition - new Vector3(xRndShift, 0, 0), Quaternion.identity, movementType);
        InstantiateEnemy(enemy, centerEnemyPosition + new Vector3(xRndShift, 0, 0), Quaternion.identity, movementType);
    }

    // Instanciación de un enemigo en función de los valores recibidos
    void InstantiateEnemy(GameObject enemyPrefab, Vector3 enemyPosition, Quaternion enemyRotation,
        MovementType movementType = MovementType.Straight, AttackType attackType = AttackType.Shoot)
    {
        // Instancia
        GameObject newEnemyInstance = (GameObject)Instantiate(enemyPrefab, enemyPosition, enemyRotation);

        // Movimiento
        SetMovement(newEnemyInstance, movementType);

        // Ataque
        SetAttack(newEnemyInstance, attackType);
    }

    // Tipo de movimiento para nuevos enemigos en función de la probabilidad
    // especificada para cada uno de ellos
    MovementType GetMovementType(float straightPercentage = 0.75f, float sinPercentage = 0.25f)
    {
        float rnd = Random.Range(0.0f, 1.0f);

        if (rnd <= straightPercentage)
            return MovementType.Straight;
        else
            return MovementType.Sin;
    }

    // Añade el componente de movimiento a un enemigo
    void SetMovement(GameObject enemyInstance, MovementType movementType)
    {
        switch(movementType)
        {
            case MovementType.Straight:
                enemyInstance.AddComponent<EnemyMoveStraight>();
                break;
            case MovementType.Sin:
                enemyInstance.AddComponent<EnemyMoveSin>();
                break;
            default:
                break;
        }
    }

    // Añade el componente de movimiento a un enemigo
    void SetAttack(GameObject enemyInstance, AttackType attackType)
    {
        switch (attackType)
        {
            case AttackType.Shoot:
                enemyInstance.AddComponent<EnemyShoot>();
                enemyInstance.GetComponent<EnemyShoot>().EnemyBullet = enemyBullet;
                break;
            default:
                break;
        }
    }
}

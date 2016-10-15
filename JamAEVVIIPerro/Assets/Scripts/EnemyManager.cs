using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    // Patrones de oleadas de enemigos
    private enum WavePattern
    {
        Three_Straight,
        Three_Sin,
        Three_Sin_Line,
        Cone,
        Stairs_Left,
        Stairs_Right,
        Hunters_Two,
        Hunters_Three,
        Two_Sides,
        Five_Mix
    }

    // Número de patrones de oleadas
    private int numWavePatters;

    // Tipos de movimiento de los enemigos
    private enum MovementType
    {
        Straight,
        Sin,
        Follow
    }

    // Tipos de ataque de los enemigos
    private enum AttackType
    {
        NoAttack,
        Shoot
    }

    // Márgenes del mapa de juego
    private float X_MIN = -7.0f;
    private float X_MAX = 7.0f;
    
    private float Y_MIN = -8.0f;
    private float Y_MAX = 8.0f;

    // Distancia mínima entre enemigos
    private float X_MIN_DIST = 1.0f;
    private float Y_MIN_DIST = 1.0f;

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
        numWavePatters = System.Enum.GetNames(typeof(WavePattern)).Length;
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
            GenerateNextWave();
        }
    }

    // Next wave random generation
    void GenerateNextWave()
    {
        WavePattern nextWave = WavePattern.Five_Mix; //(WavePattern)Random.Range(0, numWavePatters);

        switch(nextWave)
        {
            case WavePattern.Three_Straight:
                GenerateWaveThreeEnemies(MovementType.Straight, AttackType.Shoot);
                break;
            case WavePattern.Three_Sin:
                GenerateWaveThreeEnemies(MovementType.Sin, AttackType.NoAttack);
                break;
            case WavePattern.Three_Sin_Line:
                GenerateWaveThreeEnemies(MovementType.Sin, AttackType.Shoot, true);
                break;
            case WavePattern.Cone:
                GenerateWaveCone(MovementType.Straight, AttackType.NoAttack);
                break;
            case WavePattern.Stairs_Left:
                GenerateWaveStairs(MovementType.Straight, AttackType.NoAttack, true);
                break;
            case WavePattern.Stairs_Right:
                GenerateWaveStairs(MovementType.Straight, AttackType.NoAttack, false);
                break;
            case WavePattern.Hunters_Two:
                break;
            case WavePattern.Hunters_Three:
                break;
            case WavePattern.Two_Sides:
                GenerateWaveTwoSides(MovementType.Straight, AttackType.Shoot);
                break;
            case WavePattern.Five_Mix:
                //GenerateWaveFiveMix();
                break;
            default:
                break;
        }
    }

    // Genera un único enemigo en una posición aleatoria del mapa
    void GenerateOneEnemy(MovementType movementType, AttackType attackType = AttackType.Shoot)
    {
        // Tipo de movimiento del enemigo
        if (movementType == null)
            movementType = GetMovementType();

        // Posición del enemigo
        float xRndPosition = Random.Range(X_MIN, X_MAX);
        Vector3 newEnemyPosition = new Vector3(xRndPosition, Y_MAX + Y_MIN_DIST, 0.0f);

        // Creación del enemigo
        InstantiateEnemy(enemy, newEnemyPosition, movementType, attackType);
    }

    // Genera una oleada de tres enemigos en paralelo o en línea
    void GenerateWaveThreeEnemies(MovementType movementType, AttackType attackType, bool line = false)
    {
        // Posición de cada enemigo
        Vector3[] enemiesPosition = new Vector3[3];

        if (line)
        {
            // Enemigos en línea
            float xRndPosition = Random.Range(X_MIN, X_MAX);
            enemiesPosition[0] = new Vector3(xRndPosition, Y_MAX, 0.0f);
            enemiesPosition[1] = new Vector3(xRndPosition, Y_MAX + Y_MIN_DIST, 0.0f);
            enemiesPosition[2] = new Vector3(xRndPosition, Y_MAX + Y_MIN_DIST * 2, 0.0f);
        }
        else
        {
            // Enemigos en paralelo
            float xCenterPosition = GetCenterPosition_X();
            float xRndDistance = Random.Range(X_MIN_DIST, GetHalfDistance_X());
            enemiesPosition[0] = new Vector3(xCenterPosition, Y_MAX, 0.0f);
            enemiesPosition[1] = new Vector3(xCenterPosition - xRndDistance, Y_MAX + Y_MIN_DIST, 0.0f);
            enemiesPosition[2] = new Vector3(xCenterPosition + xRndDistance, Y_MAX + Y_MIN_DIST * 2, 0.0f);
        }

        // Creación de los enemigos
        InstantiateEnemy(enemy, enemiesPosition[0], movementType, attackType);
        InstantiateEnemy(enemy, enemiesPosition[1], movementType, attackType);
        InstantiateEnemy(enemy, enemiesPosition[2], movementType, attackType);
    }

    // Genera una oleada de cinco enemigos en cuña
    void GenerateWaveCone(MovementType movementType, AttackType attackType)
    {
        float xCenterPosition = GetCenterPosition_X();
        float xRndDistance = Random.Range(X_MIN_DIST, GetHalfDistance_X() / 2);

        InstantiateEnemy(enemy, new Vector3(xCenterPosition, Y_MAX, 0.0f), movementType, attackType);
        InstantiateEnemy(enemy, new Vector3(xCenterPosition - xRndDistance, Y_MAX + Y_MIN_DIST, 0.0f), movementType, attackType);
        InstantiateEnemy(enemy, new Vector3(xCenterPosition + xRndDistance, Y_MAX + Y_MIN_DIST, 0.0f), movementType, attackType);
        InstantiateEnemy(enemy, new Vector3(xCenterPosition - xRndDistance * 2, Y_MAX + Y_MIN_DIST * 2, 0.0f), movementType, attackType);
        InstantiateEnemy(enemy, new Vector3(xCenterPosition + xRndDistance * 2, Y_MAX + Y_MIN_DIST * 2, 0.0f), movementType, attackType);
    }

    // Genera una oleada de cinco enemigos en escalera
    void GenerateWaveStairs(MovementType movementType, AttackType attackType, bool startingLeft)
    {
        float xCenterPosition = GetCenterPosition_X();
        float xRndDistance = Random.Range(X_MIN_DIST, GetHalfDistance_X() / 2);

        float[] enemiesSpawnY = new float[5];
        float stairsFactorInclination = 1.0f;

        for (int i = 0; i < 5; ++i)
            enemiesSpawnY[i] = Y_MAX + Y_MIN_DIST * (startingLeft ? 4 - i : i) * stairsFactorInclination;

        InstantiateEnemy(enemy, new Vector3(xCenterPosition - xRndDistance * 2, enemiesSpawnY[0], 0.0f), movementType, attackType);
        InstantiateEnemy(enemy, new Vector3(xCenterPosition - xRndDistance, enemiesSpawnY[1], 0.0f), movementType, attackType);
        InstantiateEnemy(enemy, new Vector3(xCenterPosition, enemiesSpawnY[2], 0.0f), movementType, attackType);
        InstantiateEnemy(enemy, new Vector3(xCenterPosition + xRndDistance, enemiesSpawnY[3], 0.0f), movementType, attackType);
        InstantiateEnemy(enemy, new Vector3(xCenterPosition + xRndDistance * 2, enemiesSpawnY[4], 0.0f), movementType, attackType);
    }

    // Genera una oleada compuesta por dos líneas de enemigos
    void GenerateWaveTwoSides(MovementType movementType, AttackType attackType)
    {
        float xCenterPosition = GetCenterPosition_X();
        float xRndDistance = Random.Range(X_MIN_DIST, GetHalfDistance_X());

        InstantiateEnemy(enemy, new Vector3(xCenterPosition - xRndDistance, Y_MAX, 0.0f), movementType, attackType);
        InstantiateEnemy(enemy, new Vector3(xCenterPosition - xRndDistance, Y_MAX + Y_MIN_DIST, 0.0f), movementType, attackType);
        
        InstantiateEnemy(enemy, new Vector3(xCenterPosition + xRndDistance, Y_MAX, 0.0f), movementType, attackType);
        InstantiateEnemy(enemy, new Vector3(xCenterPosition + xRndDistance, Y_MAX + Y_MIN_DIST, 0.0f), movementType, attackType);
    }

    // Instanciación de un enemigo concreto en función de los valores recibidos
    void InstantiateEnemy(GameObject enemyPrefab, Vector3 enemyPosition,
        MovementType movementType, AttackType attackType)
    {
        // Instancia
        GameObject newEnemyInstance = (GameObject)Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);

        // Componentes
        SetMovement(newEnemyInstance, movementType); // Movimiento
        SetAttack(newEnemyInstance, attackType); // Ataque
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

    // Añade el componente de ataque a un enemigo
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

    // Devuelve la distancia de medio mapa en el eje X
    float GetHalfDistance_X()
    {
        return (X_MAX - X_MIN) / 2;
    }

    // Devuelve la posición central del mapa en el eje X
    float GetCenterPosition_X()
    {
        return X_MIN + GetHalfDistance_X();
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
}

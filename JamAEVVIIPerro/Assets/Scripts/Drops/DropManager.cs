using UnityEngine;
using System.Collections;

public class DropManager : MonoBehaviour {

    #region Singleton
    public static DropManager DropManagerInstance;

    void Awake()
    {
        if (DropManagerInstance == null)
            DropManagerInstance = gameObject.GetComponent<DropManager>();
    }
    #endregion

    [Header("Drop percentage")]
    public int lifeDropPercentage = 1;
    public int shootLevelPercentage = 5;
    public int grandmaPercentage = 1;

    [Header("Seconds to destroy drops")]
    public int timeToDestroy = 5;

    [Header("Drops")]
    public GameObject lifeDrop;
    public GameObject shootLevelDrop;
    public GameObject grandmaDrop;

    public void basicEnemyDrop(Vector3 position)
    {
        if (Random.Range(0, 100) < lifeDropPercentage & GameManager.GameManagerInstance.lifes < 5)
        {
            GameObject newDropInstance = (GameObject)Instantiate(lifeDrop, position, Quaternion.identity);
        }
        else if (Random.Range(0, 100) < shootLevelPercentage)
        {
            GameObject newDropInstance = (GameObject)Instantiate(shootLevelDrop, position, Quaternion.identity);
        }
        else if (Random.Range(0, 100) < grandmaPercentage)
        {
            GameObject newDropInstance = (GameObject)Instantiate(grandmaDrop, position, Quaternion.identity);
        }

    }
}

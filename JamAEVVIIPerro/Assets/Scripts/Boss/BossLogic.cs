using UnityEngine;
using System.Collections;

public class BossLogic : MonoBehaviour {

    // Etapas del Boss: 3 -> 5 -> 7 -> Dead
    private enum Stage
    {
        Three_Heads,
        Five_Heads,
        Seven_Heads
    }

    // Etapa actual
    private Stage currentStage = Stage.Three_Heads;

    // Invulnerable
    private bool invulnerable = true;

    // Número de cabezas destruidas
    private int numHeadsDestroyed = 0;
    public int numHeadsBoss = 3;

    public bool Invulnerable
    {
        get { return invulnerable; }
        set { invulnerable = value; }
    }

	void Start () {
	}
	
	void Update () {
	}

    // Activa el Boss cuando ha entrado completamente en la escena
    public void Activate()
    {
        Invulnerable = false;
        currentStage = Stage.Three_Heads;

        foreach (Transform child in transform)
            child.GetComponent<EnemyShoot>().enabled = true;
    }

    // Cabeza destruida
    public void HeadDestroyed()
    {
        ++numHeadsDestroyed;

        switch (currentStage)
        {
            case Stage.Three_Heads:
                currentStage = Stage.Five_Heads;
                break;
            case Stage.Five_Heads:
                currentStage = Stage.Seven_Heads;
                break;
            case Stage.Seven_Heads:
                if (numHeadsDestroyed == numHeadsBoss) BossDefeated();
                break;
            default:
                break;
        }
    }

    // Enemigo destruido
    private void BossDefeated()
    {
        Destroy(this.gameObject);
        EnemyManager.enemyManagerInstance.BossDefeated();
    }
}

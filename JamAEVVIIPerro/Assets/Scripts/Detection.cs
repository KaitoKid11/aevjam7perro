using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {
    
    public int index;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Tags.Bloque && this.name == Tags.NameSpawn)
        {
            transform.parent.transform.parent.GetComponent<SpawnBlock>().SpawnBlockUnit(this.transform, index);
        }

        if (other.tag == Tags.Intro && this.name == Tags.NameDelete)
        {
            transform.parent.transform.parent.GetComponent<SpawnBlock>().DeleteBlockUnit(other);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Bloque && this.name == Tags.NameDelete)
        {
            transform.parent.transform.parent.GetComponent<SpawnBlock>().DeleteBlockUnit(other);
        }
    }
}

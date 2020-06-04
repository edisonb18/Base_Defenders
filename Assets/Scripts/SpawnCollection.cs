using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollection : MonoBehaviour
{
    public GameObject[] collection;
    public GameObject GetObject()
    {
        GameObject selec = null;
        if (0 < collection.Length)
            selec = collection[Random.Range(0, collection.Length)];
        return selec;
    }
}

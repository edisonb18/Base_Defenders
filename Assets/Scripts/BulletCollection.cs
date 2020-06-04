using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollection : MonoBehaviour
{
    public GameObject[] collection;
    public int level=1;
    public GameObject GetObject()
    {
        GameObject selec = null;
        if (0 < collection.Length)
            selec = collection[Mathf.Min(level-1, collection.Length)];
        return selec;
    }
    public void LevelUp()
    {
        if (level < collection.Length)
            level++;
    }
    public void LevelDown()
    {
        if (level > 1)
            level--;
    }
}

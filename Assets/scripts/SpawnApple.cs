using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple : MonoBehaviour
{
    public static int numberOfTree = 0;
    void Start()
    {
        test.ListOfSpawnApple.Add(gameObject);
    }

    public void AddToListOfSpawnPoints()
    {
        test.ListOfSpawnApple.Add(gameObject);
    }
}

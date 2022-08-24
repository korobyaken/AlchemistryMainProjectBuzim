using sys = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    readonly List<GameObject> temprarySpawnPoints = test.ListOfSpawnApple;
    List<GameObject> spawnPoints;
    public GameObject apple;
    // Start is called before the first frame update
    void Start()
    {
        apple = GameObject.Find("Apple");
        spawnPoints = temprarySpawnPoints;
        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            int indexOfSpawnPoint = Random.Range(0, test.ListOfSpawnApple.Count);
            GameObject spawn = Instantiate(apple, spawnPoints[indexOfSpawnPoint].transform);
            spawn.GetComponent<HingeJoint>().connectedBody = spawnPoints[indexOfSpawnPoint].GetComponent<Rigidbody>();
            Debug.Log(spawn.transform.position);
            spawnPoints.Remove(spawnPoints[indexOfSpawnPoint]);
        }
           
    }
}

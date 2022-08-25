using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalkaStupki : MonoBehaviour
{
    public GameObject stp1;

    [HideInInspector]
    public Stupka stp;
    
    public static event Action AMortarHit;
    public static event Action AMortarSpawn;

    string where = "Ступка";


    private void Start()
    {
        stp = stp1.GetComponent<Stupka>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Material")
        {
            GameObject go = collision.gameObject;
            if (go.GetComponent<ItemMaterial>().InMortar)
            {
                string[] name = new string[] { go.GetComponent<ItemMaterial>().nameUI };
                go.GetComponent<ItemMaterial>().Kicks++;
                AMortarHit?.Invoke();
                if (stp.needKicks == go.GetComponent<ItemMaterial>().Kicks)
                {
                    Debug.Log("auiwfiug");
                    AMortarSpawn?.Invoke();
                    string result = ItemMaterial.GetReciptes(where, name);
                    if (ItemMaterial.FindIndex(result) != -1)
                    {
                        GameObject newObj = Instantiate(test.listOfItems[ItemMaterial.FindIndex(result)], go.transform.position, go.transform.rotation);
                        Destroy(go);
                    }
                }
            }
        }
    }
}

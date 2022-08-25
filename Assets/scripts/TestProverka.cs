using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProverka : MonoBehaviour
{
    public int kicks = 0;

    //public Stupka stp;

    //public GameObject mortarSpawn;

    //string where = "Ступка";

    //public static event Action spawn;

    private void OnCollisionEnter(Collision collision)
    {
        kicks++;
        Debug.Log("Больно");
        //Debug.Log("0000000000000000000000000");
        //if (collision.gameObject.tag == "Stupka")
        //{
        //    Debug.Log("1111111111111111111111111");
        //    GameObject go = this.gameObject;
        //    if (go.GetComponent<ItemMaterial>().InMortar)
        //    {
        //        Debug.Log("22222222222222222222222222222");
        //        string[] name = new string[] { go.GetComponent<ItemMaterial>().nameUI };
        //        go.GetComponent<ItemMaterial>().Kicks++;
        //        if (stp.needKicks == go.GetComponent<ItemMaterial>().Kicks)
        //        {
        //            Debug.Log("33333333333333333333333333333");
        //            spawn?.Invoke();
        //            string result = ItemMaterial.GetReciptes(where, name);
        //            if (ItemMaterial.FindIndex(result) != -1)
        //            {
        //                Debug.Log("444444444444444444444444444444");
        //                GameObject newObj = Instantiate(test.listOfItems[ItemMaterial.FindIndex(result)], go.transform);
        //                Destroy(go);
        //            }
        //        }
        //    }
        }

}

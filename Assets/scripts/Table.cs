using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    [SerializeField]
    const string where = "Стол";

    GameObject[] tableIngr = new GameObject[2];
    public GameObject temprary;

    [SerializeField]
    int quantity = 0;

    string result = "";

    GameObject spawned;
    bool fl = true;

    GameObject spawn;

    public GameObject rotationObject;

    public string[] Recipte = new string[5];

    public string[] ingr = new string[4];
    public string[] ingrEmpty = new string[4];
    private int flag = 0;

    public float distanceX;
    public float distanceY;
    public float distanceZ;

    public float rotationX;
    public float rotationY;
    public float rotationZ;

    public Canvas congratulation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Material")
        {
            quantity++;
            if (quantity < 2)
            {
            ingr[flag] = other.GetComponent<ItemMaterial>().nameUI;
            tableIngr[flag] = other.gameObject;

            }

            if (quantity == 2)
            {
                result = ItemMaterial.GetReciptes(where, ingr);

            }
            if (ItemMaterial.FindIndex(result) != -1 & quantity == 2)
            {
                spawn = Instantiate(test.listOfItems[ItemMaterial.FindIndex(result)], new Vector3(this.transform.position.x + distanceX, this.transform.position.y + distanceY), this.transform.rotation);
                result = "nope";
                for(int i = 0; i < tableIngr.Length; i++)
                {
                    Destroy(tableIngr[i]);
                }
                ingr = ingrEmpty;
            }
            
            
            if (flag == 5)
            {
                ingr = ingrEmpty;
                flag = 0;
            }
            flag++;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Material")
        {
            quantity--;
            flag--;
            Array.Sort(tableIngr);

            for(int i = 0; i < tableIngr.Length; i++)
            {
                if (tableIngr[i] == other.gameObject)
                {
                    tableIngr[i] = null;
                }
            }

            
        }
    }
}

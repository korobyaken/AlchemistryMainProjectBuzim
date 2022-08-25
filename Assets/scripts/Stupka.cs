using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stupka : MonoBehaviour
{
    [HideInInspector]
    public int needKicks = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Material")
        {
            other.gameObject.GetComponent<ItemMaterial>().InMortar = true;
            needKicks = other.gameObject.GetComponent<ItemMaterial>().needKicks;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Material")
        {
            other.gameObject.GetComponent<ItemMaterial>().InMortar = false;
        }
    }

}

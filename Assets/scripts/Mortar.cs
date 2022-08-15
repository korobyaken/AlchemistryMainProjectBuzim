using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : MonoBehaviour
{
    [SerializeField]
    int kicks = 0;
    [SerializeField]
    string where = "Ступка";
    public GameObject ingridient;
    [SerializeField]
    int quantityInMortar = 0;

    private void OnTriggerEnter(Collider other)
    {
        quantityInMortar++;
        if (other.tag == "Material")
        {
            ingridient = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        quantityInMortar--;
    }
}

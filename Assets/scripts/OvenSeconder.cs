using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenSeconder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Oven")
        {
            other.GetComponent<Oven>().inOven = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Oven")
        {
            other.GetComponent<Oven>().inOven = false;
            other.GetComponent<Oven>().timerOn = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProverka : MonoBehaviour
{
    [SerializeField]
    int kicks = 0;

    private void OnCollisionEnter(Collision collision)
    {
        kicks++;
        Debug.Log("Больно");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    public Vector3 transformScale;
    void Start()
    {
        transformScale = this.gameObject.transform.localScale;
    }

}

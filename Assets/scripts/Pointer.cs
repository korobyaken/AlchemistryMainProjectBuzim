using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public float lenght = 555f;
    public GameObject Dot;
    public VRInputModule m_inputmModule;

    private LineRenderer line = null;
    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Material")
        {
            Debug.Log("Kosanie");
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        PointerEventData data = m_inputmModule.GetData();

        float taregLenght = data.pointerCurrentRaycast.distance == 0 ? lenght : data.pointerCurrentRaycast.distance;
        RaycastHit hit = CreateRaycast(lenght);
        Vector3 endpos = transform.position + (transform.forward * taregLenght);
        if (hit.collider != null)
            endpos = hit.point;

        Dot.transform.position = endpos;

        line.SetPosition(0, transform.position);
        line.SetPosition(1, endpos);
    }

    private RaycastHit CreateRaycast(float lenght)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, lenght);

        return hit;

    }
}



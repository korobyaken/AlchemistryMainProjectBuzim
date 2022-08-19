using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public float lenght = 555f;
    public GameObject Dot;
    public VRInputModule m_inputmModule;

    //[SerializeField]
    //Ray rayForName;
    //[SerializeField]
    //RaycastHit hitForName;

    private LineRenderer line = null;
    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }


    private void Start()
    {

    }
    void FixedUpdate()
    {
        UpdateLine();


    }

    private void UpdateLine()
    {
        //Debug.Log("Update Line");
        PointerEventData data = m_inputmModule.GetData();

        float taregLenght = data.pointerCurrentRaycast.distance == 0 ? lenght : data.pointerCurrentRaycast.distance;
        RaycastHit hit = CreateRaycast(lenght);
        Vector3 endpos = transform.position + (transform.forward * taregLenght);

        line.SetPosition(0, transform.position);
        line.SetPosition(1, endpos);

        endpos = hit.point;
        if (hit.collider != null)
        {
            GameObject other = hit.collider.gameObject;

            Effects.ShowName(other);
        }


        Dot.transform.position = endpos;

       




    }

    private RaycastHit CreateRaycast(float lenght)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, lenght);
        //Debug.DrawRay(transform.position, transform.forward, Color.yellow, Mathf.Infinity);

        return hit;

    }
}



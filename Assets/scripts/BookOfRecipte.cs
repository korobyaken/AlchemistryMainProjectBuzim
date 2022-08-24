using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOfRecipte : MonoBehaviour
{

    public GameObject page;
    public Canvas CanvasWithPages;
    

    private void Start()
    {
        page.SetActive(false);
    }

    private void Update()
    {
        CanvasWithPages.transform.position = new Vector3 (page.transform.position.x, page.transform.position.y+0.7f, page.transform.position.z);
    }

    public void ShowReciptes()
    {
        page.GetComponent<GameObject>().SetActive(true);
    }

}

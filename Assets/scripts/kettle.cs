using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kettle : MonoBehaviour
{
    [SerializeField]
    const string where = "Котёл";


    public static event Action kettleNonRecipte;
    public static event Action kettleTimeOut;
    public static event Action SpawnObj;

    public GameObject temprary;

    public GameObject kottelPosition;

    public bool timerOn = false;

    string result = "";

    GameObject spawned;

    public Canvas timerCanvas;
    public Slider timerSlider;

    public float time = 100f;
    public float timeLeft = 0f;
    float valueTime;

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

    private void Start()
    {
        timerCanvas.enabled = false;
        timeLeft = time;
    }

    public void SetReciptes(string[] arr)
    {
        Array.Sort(arr);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Material")
        {
            timerOn = true;
            timeLeft = time;

            
            ingr[flag] = other.GetComponent<ItemMaterial>().nameUI;
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Invoke("Destroy", 5f);

            other.gameObject.SetActive(false);

            if (flag == 5)
            {
                ingr = ingrEmpty;
                flag = 0;
                timeLeft = 0;
            }
            flag++;
        }

    }

    public void Destroy(GameObject go)
    {
        Destroy(go);
        CancelInvoke();
    }

    private void FixedUpdate()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                if (!timerCanvas.enabled)
                {
                    timerCanvas.enabled = true;
                }
                timeLeft -= Time.deltaTime/5f;
                timerSlider.value = 1 - timeLeft / time;
            }
            else
            {
                timerCanvas.enabled = false;
                timerSlider.value = 0;
                timerOn = false;
                result = ItemMaterial.GetReciptes(where, ingr);
                if (ItemMaterial.FindIndex(result) != -1)
                {
                    SpawnObj?.Invoke();
                    spawn = Instantiate(test.listOfItems[ItemMaterial.FindIndex(result)], kottelPosition.transform.position, this.transform.rotation);
                    result = "nope";
                }
                else
                {
                    kettleNonRecipte.Invoke();
                }
                for (int i = 0; i < ingr.Length; i++)
                {
                    ingr[i] = null;
                }
                flag = 0;
                
            }
        }
    }
}

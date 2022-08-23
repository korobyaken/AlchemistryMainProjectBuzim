using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oven : MonoBehaviour
{
    [SerializeField]
    const string where = "Печь";

    //public Vector3 first;

    public bool inOven;

    public bool timerOn = false;

    GameObject spawn;

    public bool destroy = true;

    string result = "";

    public Canvas timerCanvas;
    public Canvas buttonCanvas;

    public Slider timerSlider;

    public Button buttonForSuccesCooked;

    public GameObject positionGO;

    [SerializeField]GameObject fill;

    public float time = 100f;
    public float timeLeft = 0f;

    public GameObject rotationObject;
    GameObject rightHand;
    GameObject leftHand;

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
    public Color32 testColor;
    private void Start()
    {
        //rightHand = FindObjectOfType;
        timerCanvas.enabled = false;
        buttonCanvas.enabled = false;
        timeLeft = time;
        inOven = false;
        //buttonForSuccesCooked.enabled = false;
        Debug.Log("bbbbb");
    }


    public void NotDestroy()
    {
        destroy = false;
        test.stateOfOvenSlider = 3;
        timerCanvas.enabled = false;
        buttonCanvas.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Material")
        {
            ingr[flag] = other.GetComponent<ItemMaterial>().nameUI;
            other.gameObject.SetActive(false);
            flag++;
            if (flag == 5)
            {
                for (int i = 0; i < ingr.Length; i++)
                {
                    ingr[i] = null;
                }
                flag = 0;
            }
        }

    }

    private void FixedUpdate()
    {



        switch (test.stateOfOvenSlider)
        {
            case 0:
                if (inOven & !timerOn)
                {
                    timerCanvas.enabled = true;
                    timerOn = true;
                    timeLeft = time;
                    test.stateOfOvenSlider++;
                }
                break;
            case 1:
                if (!inOven)
                {
                    timerOn = false;
                    timeLeft = time;
                    test.stateOfOvenSlider--;
                    break;
                }
                fill.GetComponent<Image>().color = new Vector4(0 / 255.0f, 255 / 255.0f, 0 / 255.0f, 1);
                timeLeft -= Time.deltaTime / 5f;
                timerSlider.value = 1 - timeLeft / time;
                if(timeLeft <= 0)
                {
                    destroy = true;
                    result = ItemMaterial.GetReciptes(where, ingr);
                    if (ItemMaterial.FindIndex(result) != -1)
                    {
                        spawn = Instantiate(test.listOfItems[ItemMaterial.FindIndex(result)], positionGO.transform.position, this.transform.rotation);
                        result = "nope";
                    }

                    ingr = ingrEmpty;

                    fill.GetComponent<Image>().color = testColor;  /*new Vector4(255 / 255.0f, 0 / 255.0f, 0 / 255.0f, 1); */
                    test.stateOfOvenSlider++;
                    timeLeft = time;
                    timerCanvas.enabled = false;
                    goto case 2;
                }
                break;
            case 2:
                buttonCanvas.enabled = true;
                if (!inOven)
                {
                    timerOn = false;
                    test.stateOfOvenSlider--;
                    break;
                }
                else
                {
                    timerCanvas.enabled = true;
                }
                timeLeft -= Time.deltaTime / 5f;
                timerSlider.value = 1 - timeLeft / time;
                if (timeLeft <= 0)
                {
                    if (destroy)
                    {
                        Destroy(spawn);
                    }
                    test.stateOfOvenSlider++;
                    timeLeft = time;
                    timerCanvas.enabled = false;
                }
                break;
            case 3:
                buttonCanvas.enabled = false;
                test.stateOfOvenSlider = 0;
                flag = 0;
                for (int i = 0; i < ingr.Length; i++)
                {
                    ingr[i] = null;
                }
                break;


            default:
                break;
        }

        if (!inOven)
        {
            test.stateOfOvenSlider = 0;
            timeLeft = time;
            timerCanvas.enabled = false;

        }

        if (timerOn)
        {
            if (timeLeft > 0)
            {
                
            }
            else
            {
                timerCanvas.enabled = false;
                timerSlider.value = 0;
                timerOn = false;
                result = ItemMaterial.GetReciptes(where, ingr);
            }
        }
    }
}

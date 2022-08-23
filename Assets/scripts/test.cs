using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class test : MonoBehaviour
{
    public static int stateOfOvenSlider = 0;


    public bool flag = true;

    public string txt;

    //public static StreamReader fileObj;

    public static List<string> listOfItemsOnShelf = new List<string>();

    public static List<GameObject> listOfItems = new List<GameObject>();

    public static List<string> listOfUIName = new List<string>();

    float[] arr1 = new float[] { 25, 15, 10, 30, 25 };
    float[] arr2 = new float[] { 180, 130, 100, 120, 150 };
    float[] arr3 = new float[] { 2000, 1300, 1500, 1200, 1400 };
    float[] arr4 = new float[] { 1000, 500, 600, 700, 2000};
    float min = 1000000;
    float max = 0;
    float z = 0;
    

    

    public static Recipe[] arReciepes;

    public static StreamReader fileObj;

    private void minMax(float[] ar)
    {
        foreach (int i in ar)
        {
            if (i < min)
            {
                min = i;
            }
            if (i > max)
            {
                max = i;
            }
        }
    }

    private float Z(float _, float max, float min)
    {
        return (_ - min)/(max - min);
    }

    private void Start()
    {
        Debug.Log("asfhyawegfuiybvscvhjiabwgyiawruiobvhuaioerbgu");
        float[][] arrays = new float[][] { arr1, arr2, arr3, arr4 };
        int asdwad = 0;
        foreach (float[] ar in arrays)
        {
            minMax(ar);
            
            Debug.Log($"Массив №{asdwad}");
            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = Z(ar[i], max, min);
                Debug.Log(ar[i]);
            }
            asdwad++;
        }

        fileObj = new StreamReader("Assets/Reciptes/Reciepes.json");
        string json = fileObj.ReadToEnd();
        fileObj.Close();
        ReciepesList recipesList = JsonUtility.FromJson<ReciepesList>(json);
        arReciepes = recipesList.reciepes;
        string[] strr = arReciepes[0].ingredients;
        if (ItemMaterial.FindIndex(txt) != -1)
        {
            Instantiate(test.listOfItems[ItemMaterial.FindIndex(txt)], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);

        }


    }

    [Serializable]
    public class Recipe
    {
        public string action;
        public string[] ingredients;
        public string result;
    }

    public class ReciepesList
    {
        public Recipe[] reciepes;
    }
    void Update() {

        if (flag)
        {
            flag = false;

            //Instantiate(test.listOfItems[ItemMaterial.FindIndex(ItemMaterial.GetReciptes("gg", ar1))], this.transform.position, this.transform.rotation);
        }
    }
}



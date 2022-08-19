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

    public static Recipe[] arReciepes;

    public static StreamReader fileObj;

    private void Start()
    {

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



using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class ItemMaterial : MonoBehaviour
{
    public string nameUI;                                                                                               //Название 
    public int needKicks = 5;                                                                                           //кол-во нужных ударов для ступки
    public int Kicks = 0;
    public bool InMortar = false;


    public static bool OnArray(List<string> ar, string name)                                                            //Метод для поиска строки внутри листа
    {
        for (int i = 0; i < ar.Count; i++)
        {
            if(ar[i] == name)
            {
                return true;
            }
        }
        return false;
    }

    public static int FindIndex(string name)                                                                            //Метод для поиска индекса объекта в массиве с именами всех объектов
    {
        for (int i = 0; i < test.listOfUIName.Count; i++)
        {
            if (test.listOfUIName[i] == name)
            {
                return i;
            }
        }

        return -1;
    }

    public static string[] DeleteLastIngredient(string[] ar)                                                            //Метод для удаления последнего не нулевого объекта в масссиве
    {
        for (int i = 0; i < ar.Length; i++)
        {
            if (i + 1 == ar.Length && ar[i] != null)
            {
                ar[i] = null;
                return ar;
            }
            if (ar[i] == null)
            {
                ar[i - 1] = null;
                return ar;
            }

        }
        return ar;

    }

    public void Start()
    {
        test.listOfUIName.Add(nameUI);                                                                              //Добавляет имя объекта в лист с именами всех объектов
        test.listOfItems.Add(gameObject);                                                                           //Добавляет объект в лист со всеми объектами с тем же индексом, что и имя
    }

    public static int HowManyElements(string[] ar )                                                                     //метод для поиска кол-ва не нулевых элементов массива
    {
        int quantity = ar.Length;
        foreach (string i in ar)
        {
            if (i == null | i == "")
            {
                quantity--;
            }
        }
        return quantity;

    }

    public static bool ArrayComparison(string[] array1, string[] array2)                                                //Сравнение массивов
    {

        string[] ar1 = new string[array1.Length];
        Array.Copy(array1, ar1, ar1.Length);

        string[] ar2 = new string[array2.Length];
        Array.Copy(array2, ar2, ar2.Length);

        Array.Sort(ar1);
        Array.Sort(ar2);

        if (HowManyElements(ar1) == HowManyElements(ar2))                                                               //Сравнение кол-ва не нулевых элементов
        {
            if (ar1.Length < ar2.Length)                                                                                //Если 1ый массив из json`а
            {

                foreach (string elementOfAr1 in ar1)                                                                    //Берём один элемент из массива ar1
                {
                    for (int i = 0; i < ar2.Length; i++)
                    {
                        if (ar2[i] != null & ar2[i] != "")
                        {
                            if (ar2[i] != elementOfAr1)
                            {
                                return false;
                            }
                            else
                            {
                                ar2[i] = null;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (string elementOfAr2 in ar2)
                {
                    for (int i = 0; i < ar1.Length; i++)
                    {
                        if (ar1[i] != null & ar1[i] != "")
                        {
                            if (ar1[i] != elementOfAr2)
                            {
                                return false;
                            }
                            else
                            {
                                ar1[i] = null;
                                break;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            return false;
        }
        return true;

    }

    public static string GetReciptes(string where, string[] ar)                                                         //Метод для посика рецепта в json'е состоящего из ингридиентов массива
    {
        string nope = "nope";
        test.Recipe[] thisArrayOfReciepes = test.arReciepes;

        for (int i = 0; i < thisArrayOfReciepes.Length; i++)
        {
            if (ArrayComparison(ar, thisArrayOfReciepes[i].ingredients) & where == thisArrayOfReciepes[i].action)
            {
                return thisArrayOfReciepes[i].result;
            }
        }
        return nope;
    }

}
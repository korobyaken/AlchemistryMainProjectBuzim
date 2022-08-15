using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    GameObject temporary_GO;                                                                                            //Временный объект

    public float distanceX = 0f;                                                                                        //Поправка при спавне по оси X
    public float distanceY = 0f;                                                                                        //Поправка при спавне по оси Y
    public float distanceZ = 0f;                                                                                        //Поправка при спавне по оси Z
    [SerializeField]
    private int quantity = 0;                                                                                           //Количество объектов внутри триггера

    //public Vector3 gg;                                                                                                //Очень удобная штука, на будущее

    public float time = 0f;                                                                                             //Время через которое заспавнится новый объект

    GameObject spawned;                                                                                                 //Основной оъект для спавна

    private bool been = false;                                                                                          //Переменная определяющая есть такой объект на другой полке или нет
    private void OnTriggerEnter(Collider other)                                                                         //Метод вызываемый, когда объект попадает в коллайдер
    {
        Debug.Log("nknknkhnknkn mk");
        if (other.tag == "Material")                                                                                    
        {
            quantity++;
            if (ItemMaterial.OnArray(test.listOfItemsOnShelf, other.GetComponent<ItemMaterial>().nameUI) == false)      //Если этого объекута нет на другой полке
            {
                test.listOfItemsOnShelf.Add(other.GetComponent<ItemMaterial>().nameUI);                                 //Добавление имени объекта в список объектов на полках
                if (temporary_GO is null && !been)                                                                      //Если объект в первый раз
                {
                    if (temporary_GO == null)                                                                           
                    {
                        temporary_GO = other.gameObject;
                    }
                    Destroy(other.gameObject);
                    quantity--;
                    spawned = Instantiate(temporary_GO, new Vector3(this.transform.position.x + distanceX, this.transform.position.y - 5f, this.transform.position.z + distanceZ), this.transform.rotation);
                    CreateNewObject();                                                                                  //Создание объекта
                    been = true;
                    if (!spawned.GetComponent<Rigidbody>().useGravity)  
                    {
                        spawned.GetComponent<Rigidbody>().useGravity = true;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)                                                                          //Метод вызываемый при выходе из коллайдера
    {
        if (other.tag == "Material")
        {
            quantity--;
            if (quantity <= 0)
            {
                Invoke("CreateNewObject", time);                                                                              //Вызов метода создания объекта через время
            }
        }
    }
    void CreateNewObject()                                                                                              //Метод создания объекта
    {
        if (quantity <= 0)                                                                                              
        {
            if (!spawned.GetComponent<Rigidbody>().useGravity)
            {
                spawned.GetComponent<Rigidbody>().useGravity = true;
            }
            Instantiate(spawned, new Vector3(this.transform.position.x + distanceX, this.transform.position.y + distanceY, this.transform.position.z + distanceZ), this.transform.rotation);
        }
    }
}


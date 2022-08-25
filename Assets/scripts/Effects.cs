using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Effects : MonoBehaviour
{
    
    public static GameObject mt;

    public static GameObject stayOgj;

    public ParticleSystem kettleNonRecipte;
    public ParticleSystem kettleTimeOut;
    public ParticleSystem ovenNonRecipte;
    public ParticleSystem ovenTimeOut;
    public ParticleSystem kettelSpawn;
    public ParticleSystem ovenSpawn;
    //public ParticleSystem breakGlass;
    public ParticleSystem mortarSpawn;
    public ParticleSystem mortarHit;



    public Vector3 popravka;

    private void Start()
    {
        stayOgj = GameObject.FindGameObjectWithTag("Stay");
        kettle.SpawnObj += KettelSpawn;
        Oven.ovenNonRecipte += OvenNonRecipte;
        Oven.ovenTimeOut += OvenTimeOut;
        kettle.kettleNonRecipte += KettelNonRecipte;
        kettle.kettleTimeOut += KettleTimeOut;

        PalkaStupki.AMortarHit += MortarHit;
        PalkaStupki.AMortarSpawn += MortarSpawn;

        mt = GameObject.Find("NameUI");
        //Debug.Log("PanzerKampfWagenIV");
    }

    public void MortarSpawn()
    {
        mortarSpawn.Play();
    }

    public void MortarHit()
    {
        mortarHit.Play();
    }

    public void KettelSpawn()
    {
        kettelSpawn.Play();
    }

    public void KettelNonRecipte()
    {
        kettleNonRecipte.Play();
    }

    public void KettleTimeOut()
    {
        kettleTimeOut.Play();
    }

    public void OvenNonRecipte()
    {
        ovenNonRecipte.Play();
    }

    public void OvenTimeOut()
    {
        ovenTimeOut.Play();
    }

    public static void ShowName(GameObject other)
    {
        if (other.tag == "Material")
        {
            Vector3 positionObject = other.transform.position;
            mt.transform.position = new Vector3(positionObject.x + 0f, positionObject.y + .2f, positionObject.z + 0f);
            mt.GetComponent<TextMeshPro>().text = other.GetComponent<ItemMaterial>().nameUI;
            mt.transform.SetParent(other.gameObject.transform);
            mt.SetActive(true);
        }
        else
        {
            mt.SetActive(false);
            mt.transform.SetParent(stayOgj.transform);
        }
    }
}

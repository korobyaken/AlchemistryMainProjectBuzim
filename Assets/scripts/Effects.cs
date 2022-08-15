using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Effects : MonoBehaviour
{
    public ParticleSystem kettleNonRecipte;
    public ParticleSystem kettleTimeOut;
    public ParticleSystem ovenNonRecipte;
    public ParticleSystem ovenTimeOut;

    public GameObject mt;
    public GameObject spawned;

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

    public void ShowName(GameObject other, bool GO)
    {
        if (GO)
        {
            mt.GetComponent<TextMeshPro>().text = other.GetComponent<ItemMaterial>().name;
            mt.transform.SetParent(other.gameObject.transform);
            mt.SetActive(true);
        }
        else
        {
            mt.SetActive(false);
        }
    }
}

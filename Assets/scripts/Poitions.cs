using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poitions : ItemMaterial
{
    public static event Action ABreak;

    public GameObject orc;

    public Vector3 normalScale;

    public ParticleSystem explosion;

    public float distanceToEffect = 0;

    [HideInInspector]
    public Color mainColorOfExplosion;

    public static Color colorAntigravityPoition = new Color(0, 0, 255, 255);
    public static Color colorScalePlus = new Color(255, 0, 0, 255);
    public static Color colorScaleMinus = new Color(0, 255, 0, 255);

    ParticleSystem.MainModule explosionMain;

    private void Awake()
    {
        explosionMain = explosion.main;
        normalScale = orc.GetComponent<Orc>().transformScale;
    }

    public enum effects
    {
        AntiGravity,
        ScalePlus,
        ScaleMinus
    }


    public effects effect;

    public GameObject explodePartPrefab;
    public float minMagnitudeToExplode = 5f;
    public int explodeCount = 10;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.impulse.magnitude > minMagnitudeToExplode)
        {

            explosion.transform.position = transform.position;
            float distance = Vector3.Distance(orc.transform.position, transform.position);
            switch (effect)
            {
                case effects.AntiGravity:
                    //if (distanceToEffect >= distance)
                        //orc.GetComponent<Rigidbody>().useGravity = false;
                    explosionMain.startColor = colorAntigravityPoition;
                    explosion?.Play();
                    Destroy(this.gameObject);
                    return;
                case effects.ScalePlus:
                    if (distanceToEffect >= distance)
                        orc.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    explosionMain.startColor = colorScalePlus;
                    explosion?.Play();
                    Destroy(this.gameObject);
                    return;
                case effects.ScaleMinus:
                    if (distanceToEffect >= distance)
                        orc.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                    explosionMain.startColor = colorScaleMinus;
                    explosion?.Play();
                    Destroy(this.gameObject);
                    return;
            }
        }
    }
}

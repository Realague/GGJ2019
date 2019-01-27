using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private Cow cow;

    void Start()
    {
        cow = GetComponentInParent<Cow>();
        bar = transform.Find("Bar");
    }

    void Update()
    {
        if (cow.hp <= 0)
        {
            bar.localScale = new Vector3(0, 1f);
        }
        else
        {
            bar.localScale = new Vector3((float)(cow.hp) / (float)(cow.maxHp), 1f);
        }
    }
}

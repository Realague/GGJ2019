using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowshedHealthBar : MonoBehaviour
{
    private Transform bar;

    void Start()
    {
        bar = transform.Find("Bar");
    }

    void Update()
    {
        if (GameController.instance.cowshedHp <= 0)
        {
            bar.localScale = new Vector3(0, 1f);
        }
        else
        {
            bar.localScale = new Vector3((float)(GameController.instance.cowshedHp) / (float)(GameController.instance.cowshedMaxHp), 1f);
        }
    }
}

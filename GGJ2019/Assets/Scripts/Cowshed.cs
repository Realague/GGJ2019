using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowshed : MonoBehaviour
{
    private Color red = new Color(1, 0, 0, 1);
    private Color baseColor = new Color(1, 1, 1, 1);
    private SpriteRenderer objectSprite;

    void Start()
    {
        objectSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cow")
        {
            StartCoroutine("Damaged");
        }
    }

    IEnumerator Damaged()
    {
        objectSprite.color = red;
        yield return new WaitForSeconds(0.25F);
        objectSprite.color = baseColor;
    }
}

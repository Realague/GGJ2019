using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private Animator myAnimator;
    [SerializeField]
    private float speed = 4f;
    public int attack = 4;
    public int hp = 1;
    private bool dead = false;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetFloat("Speed", 1);
    }

    void Update()
    {
        if (dead)
        {
            GameController.instance.nbCowLeft--;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector2(1, 0) * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cowshed")
        {
            GameController.instance.cowshedHp -= attack;
            dead = true;
        }
    }

    void OnMouseDown()
    {
        hp -= GameController.instance.playerDamage;
        if (hp <= 0)
        {
            dead = true;
        }
    }

}

using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Cow : MonoBehaviour
{
    private Color red = new Color(1, 0, 0, 1);
    private Color black = new Color(0, 0, 0, 1);
    private Color baseColor = new Color(1, 1, 1, 1);
    private Animator myAnimator;
    public AudioClip deathSound;
    public AudioClip hitSound;
    public AudioSource source;
    [NonSerialized]
    public int hp;
    Rigidbody2D myRigidBody;
    public float speed = 4f;
    public int maxHp = 1;
    private bool dead = false;
    private bool callDestroy = false;
    public int deathRoatationSpeed = 20;
    private SpriteRenderer objectSprite;

    void Start()
    {
        objectSprite = GetComponent<SpriteRenderer>();
        hp = maxHp;
        source = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (dead && !callDestroy)
        {
            myAnimator.SetBool("Death", true);
            StartCoroutine("Death");
            callDestroy = true;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector2(1, 0) * Time.deltaTime * speed);
        if (callDestroy)
        {
            transform.Rotate(new Vector3(0, 0, deathRoatationSpeed * Time.deltaTime));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cowshed" && !dead)
        {
            GameController.instance.cowshedHp -= hp;
            GameController.instance.nbCowLeft--;
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            hp -= GameController.instance.playerDamage;
            GameController.instance.money += 1 + GameController.instance.wave / 6;
            if (hp <= 0)
            {
                dead = true;
                return;
            }
            StartCoroutine("Damaged");
        }
    }

    /*void OnMouseDown()
    {
        hp -= GameController.instance.playerDamage;
        GameController.instance.money += 1 + GameController.instance.wave / 6;
        if (hp <= 0)
        {
            dead = true;
            return;
        }
        StartCoroutine("Damaged");
    }*/

    IEnumerator Death()
    {
        objectSprite.color = black;
        source.clip = deathSound;
        source.Play();
        GameController.instance.nbCowLeft--;
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        myRigidBody.gravityScale = 1f;
        yield return new WaitForSeconds(1.5F);
        Destroy(gameObject);
    }

    IEnumerator Damaged()
    {
        source.clip = hitSound;
        source.Play();
        objectSprite.color = red;
        yield return new WaitForSeconds(0.25F);
        if (!dead)
        {
            objectSprite.color = baseColor;
        }
    }
}

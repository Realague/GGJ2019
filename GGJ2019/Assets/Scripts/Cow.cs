using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Cow : MonoBehaviour
{
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

    void Start()
    {
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

    void OnMouseDown()
    {
        hp -= GameController.instance.playerDamage;
        GameController.instance.money += 1 + GameController.instance.wave / 6;
        if (hp <= 0)
        {
            dead = true;
            return;
        }
        source.clip = hitSound;
        source.Play();
    }

    IEnumerator Death()
    {
        source.clip = deathSound;
        source.Play();
        GameController.instance.nbCowLeft--;
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        myRigidBody.gravityScale = 1f;
        yield return new WaitForSeconds(1.5F);
        Destroy(gameObject);
    }
}

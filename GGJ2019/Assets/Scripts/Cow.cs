using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private Animator myAnimator;
    public AudioClip deathSound;
    public AudioClip hitSound;
    public AudioSource source;
    public int hp;

    public float speed = 4f;
    public int attack = 4;
    public int maxHp = 1;
    private bool dead = false;
    private bool callDestroy = false;
    public int deathRoatationSpeed = 20;

    void Start()
    {
        hp = maxHp;
        source = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();
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
        if (!dead)
        {
            transform.Translate(new Vector2(1, 0) * Time.deltaTime * speed);
        }
        else if (callDestroy)
        {
            transform.Rotate(new Vector3(0, 0, deathRoatationSpeed * Time.deltaTime));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cowshed" && !dead)
        {
            GameController.instance.cowshedHp -= attack;
            GameController.instance.nbCowLeft--;
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        hp -= GameController.instance.playerDamage;
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
        yield return new WaitForSeconds(1.5F);
        Destroy(gameObject);
    }
}

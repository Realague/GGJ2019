using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private Animator myAnimator;
    [SerializeField]
    private float speed = 4f;
    public int hp = 1;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetFloat("Speed", 1);
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector2(1, 0) * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cowshed")
        {
            Destroy(gameObject);
        }
    }
}

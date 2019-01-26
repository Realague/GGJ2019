using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int wave = 1;
    public int cowshedHp = 1;
    public GameObject cowshed;
    public GameObject cow;
    public int nbCowLeft = 0;
    public static GameController instance = null;
    public List<Transform> spawns;
    public int playerDamage = 1;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (nbCowLeft <= 0)
        {
            wave++;
            StartCoroutine("SpawnWave");
        }
        if (cowshedHp <= 0)
        {
            Destroy(cowshed);
            //arret jeux
        }
    }

    IEnumerator SpawnWave()
    {
        nbCowLeft = wave * 5;
        for (int i = 0; i != wave * 5; i++)
        {
            Instantiate(cow, spawns[Random.Range(0, spawns.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.2f, 1.0f));
        }
    }

}

using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    [NonSerialized]
    public int wave = 0;
    [NonSerialized]
    public int cowshedHp;
    public GameObject cowshed;
    public GameObject cow;
    public GameObject shop;

    public int shotgunSpreadLevel = 1;
    public int shotgunDamageLevel = 1;
    public int money = 0;
    public int cowshedMaxHp = 10;
    public int nbCowLeft = 0;
    public List<Transform> spawns;
    public int playerDamage = 1;
    public GameObject text;
    public int cowPerWave = 3;
    public int baseCowNumber = 3;
    public GameObject cusor;

    void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        cowshedHp = cowshedMaxHp;
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        startNewWave();
    }

    void Update()
    {
        if (nbCowLeft <= 0)
        {
            showShop();
        }
        if (cowshedHp <= 0)
        {
            Time.timeScale = 0;
            text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    public void showShop()
    {
        shop.SetActive(true);
    }

    public void startNewWave()
    {
        shop.SetActive(false);
        wave++;
        StartCoroutine("SpawnWave");
    }

    public IEnumerator SpawnWave()
    {
        GameObject cowObject = null;
        nbCowLeft = 3 + wave * cowPerWave;
        for (int i = 0; i != 3 + wave * cowPerWave; i++)
        {
            cowObject = Instantiate(cow, spawns[UnityEngine.Random.Range(0, spawns.Count)].position, Quaternion.identity);
            cowObject.GetComponent<Cow>().maxHp += wave / 4;
            cowObject.GetComponent<Cow>().speed += wave * 0.1f;
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.2f, 1.0f));
        }
    }

}

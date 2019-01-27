using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject cursor;
    public TextMeshProUGUI damageCost;
    public TextMeshProUGUI spreadCost;

    void Update()
    {
        damageCost.text = (50 * GameController.instance.shotgunDamageLevel).ToString();
        spreadCost.text = (75 * GameController.instance.shotgunSpreadLevel).ToString();
    }

    public void BuyShotgunDamage()
    {
        if (GameController.instance.money >= 50 * GameController.instance.shotgunDamageLevel)
        {
            GameController.instance.money -= 50 * GameController.instance.shotgunDamageLevel;
            GameController.instance.shotgunDamageLevel += 1;
            GameController.instance.playerDamage += 1;
        }
    }

    public void BuyShotgunSpread()
    {
        if (GameController.instance.money >= 75 * GameController.instance.shotgunSpreadLevel)
        {
            GameController.instance.money -= 75 * GameController.instance.shotgunSpreadLevel;
            GameController.instance.shotgunSpreadLevel += 1;
            cursor.transform.localScale += new Vector3(0.3f, 0.3f, 0);
        }
    }

    public void RepairCowshed()
    {
        if (GameController.instance.money >= 15 && GameController.instance.cowshedHp < GameController.instance.cowshedMaxHp)
        {
            GameController.instance.money -= 15;
            GameController.instance.cowshedHp += 1;
        }
    }

    public void startNewWave()
    {
        GameController.instance.startNewWave();
    }
    
}

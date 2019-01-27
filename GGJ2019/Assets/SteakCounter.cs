using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SteakCounter : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = GameController.instance.money.ToString();
    }
}

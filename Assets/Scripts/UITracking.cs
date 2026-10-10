using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITracking : MonoBehaviour
{
    public GameManager gm;
    public TextMeshProUGUI coinCounterUI;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    public void ChangeCoinText()
    {
        coinCounterUI.text = ("Coins: " + gm.CoinCount);
    }
}

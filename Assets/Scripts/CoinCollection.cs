using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public GameManager gm;
    public UITracking uiTrack;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        uiTrack = GameObject.FindWithTag("UI").GetComponent<UITracking>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gm.CoinCount += 1;
            uiTrack.ChangeCoinText();
            //gm.CointCount = gm.CountCount + 1;
            Destroy(gameObject);
            Debug.Log(gm.CoinCount);
        }
    }
}

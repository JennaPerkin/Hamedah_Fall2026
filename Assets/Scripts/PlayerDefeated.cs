using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefeated : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            Debug.Log("PlayerHit");
        }
    }
}

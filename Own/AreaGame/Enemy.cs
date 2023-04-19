using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject gm;
    private void Start()
    {
        gm = GameObject.Find("GameManagerO");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm?.GetComponent<GameManager>().GameOver(); // a kérdõjel miatt csak akkor fut le ha nem null a gm
        }
    }
}

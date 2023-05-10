using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject gm, player;
    public GameObject bullet;
    private void Start()
    {
        gm = GameObject.Find("GameManagerO");
        player = GameObject.Find("Player");
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        //Debug.Log("Táv: " + Vector3.Distance(transform.position, player.transform.position));
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 60)
            {
                GameObject newBullet = Instantiate(bullet, transform.position, bullet.transform.rotation);
                newBullet.transform.forward = player.transform.position - transform.position;
                yield return new WaitForSeconds(1);
            }
            yield return null;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm?.GetComponent<GameManager>().GameOver(); // a kérdõjel miatt csak akkor fut le ha nem null a gm
        }
    }
}

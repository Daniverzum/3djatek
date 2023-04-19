using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] animals;
    void Start()
    {
        InvokeRepeating("SpawnAnimal", 0, 3);
    }

    void SpawnAnimal()
    {
        int idx = Random.Range(0, animals.Length);
        Instantiate(animals[idx], new Vector3(Random.Range(-16f, 16f), 0, 19), animals[idx].transform.rotation);
    }

    /*public static void GameOver()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().enabled = false;
    }
    */
}

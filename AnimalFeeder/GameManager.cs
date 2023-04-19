using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] animals;
    void Start()
    {
        InvokeRepeating("spawnAnimal", 1, 3);
    }

    void spawnAnimal()
    {
        int idx = Random.Range(0, animals.Length);
        Instantiate(animals[idx], new Vector3(Random.Range(-15f,15f), 0.03f, 17), animals[idx].transform.rotation);
    }

    public static void GameOver()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().enabled = false;
    }
    
}

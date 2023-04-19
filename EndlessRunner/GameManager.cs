using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject background;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2, 2);
    }

    void SpawnObstacle()
    {
        Instantiate(obstacle, new Vector3(25, 0, 0), obstacle.transform.rotation);
    }

    public void GameOver()
    {
        CancelInvoke();
        background.GetComponent<RepeatBackground>().enabled = false;
    }



}

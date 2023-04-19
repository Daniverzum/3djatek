using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject background;
    int points = 0;
    public TextMeshProUGUI gameOverText, pointsText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2, 2);
        gameOverText.gameObject.SetActive(false);
    }

    void SpawnObstacle()
    {
        Instantiate(obstacle, new Vector3(25,0,0), obstacle.transform.rotation);
    }

    public void GameOver()
    {
        CancelInvoke();
        background.GetComponent<RepeatBackground>().enabled = false;
        gameOverText.gameObject.SetActive(true);
        //gameOverText.SetText("You lost");
        //gameOverText.SetText(gameOverText.text + " points: " + points);
    }

    public void PointGotten()
    {
        points++;
        //Debug.Log("points: " + points);
        pointsText.SetText("score: " + points);
    }
}

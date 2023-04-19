using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public int timeLeft;
    public TextMeshProUGUI timeText;

    private void Start()
    {
        timeText.SetText("time: " + timeLeft);
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            //Debug.Log("time: " +  timeLeft);
            timeText.SetText("time: " + timeLeft);
        }
        GameOver();
        
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        player.GetComponent<PlayerController>().enabled = false;
    }
}

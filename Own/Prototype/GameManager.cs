using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public int timeLeft;
    public TextMeshProUGUI timeText;
    private IEnumerator countdown;
    public GameObject gameOverUI;
    public static int levelNumber;

    private void Start()
    {
        gameOverUI.SetActive(false);
        timeText.SetText("time: " + timeLeft);
        countdown = Countdown();
        StartCoroutine(countdown);
        levelNumber = PlayerPrefs.GetInt("level", 1);
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
        gameOverUI.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        //Time.timeScale = 0;
        //StopAllCoroutines();
        StopCoroutine(countdown);
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        /*bool not_restarted = true;
        while (not_restarted) // or just true
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Restarted");
                not_restarted = false;
            }
        }*/
        while (!Input.GetKeyDown(KeyCode.R))
        {
            yield return null;
        }
        Debug.Log("Restarted");
        Restart();
        yield return null;
    }

    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(levelNumber);
    }

    public void LoadNextLevel()
    {
        levelNumber++;
        if (levelNumber < SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("level", levelNumber);
            SceneManager.LoadScene(levelNumber);
        }
    }
}

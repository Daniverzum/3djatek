using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void NewGame()
    {
        Debug.Log("New Game");
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene(1);
    }
    public void LoadGame()
    {
        Debug.Log("Load Game");
        SceneManager.LoadScene(PlayerPrefs.GetInt("level", 1));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winPopup;
    public GameObject gameOverPopup;
    public int gloalLimit;
    public string mainScene;

    public void ShowScores()
    {
        winPopup.gameObject.SetActive(true);
    }
    public void GameOver()
    {
        gameOverPopup.gameObject.SetActive(true);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(mainScene);
    }
}

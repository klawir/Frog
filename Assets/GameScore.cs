using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public GameObject winPopup;
    public GameObject gameOverPopup;

    public Text lifes;
    public Text score;
    public Text time;

    public int gloalLimit;
    public string mainScene;

    public void ShowScores(PlayerManager playerManager)
    {
        winPopup.gameObject.SetActive(true);
        lifes.text = playerManager._lifes.text;
        score.text = playerManager.score.text;
        time.text = playerManager.ElapsedTime.ToString();
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

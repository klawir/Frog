using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinGameManager : MonoBehaviour
{
    public GameObject winPopup;
    
    public Text lifes;
    public Text score;
    public Text time;

    public void ShowScores(PlayerManager playerManager)
    {
        winPopup.gameObject.SetActive(true);
        lifes.text = playerManager._lifes.text;
        score.text = playerManager.score.text;
        time.text = playerManager.ElapsedTime.ToString();
    }
}

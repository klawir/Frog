using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinGameManager : MonoBehaviour
{
    public GameObject winPopup;
    
    public Text lifes;
    public Text _score;
    public Text time;

    public void ShowScores(GameScore score)
    {
        winPopup.gameObject.SetActive(true);
        lifes.text = score._lifes.text;
        _score.text = score.score.text;
        time.text = PlayerData.totalTime.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossGameManager : MonoBehaviour
{
    public GameObject gameOverPopup;

    public void GameOver()
    {
        gameOverPopup.gameObject.SetActive(true);
    }
}

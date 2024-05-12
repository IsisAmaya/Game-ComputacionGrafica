using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    public TextMeshProUGUI pointsText;
    void Start()
    {   
        int playerScore = PlayerPrefs.GetInt("PlayerScore");
        pointsText.text = playerScore.ToString() + " POINTS";
        PlayerPrefs.DeleteKey("PlayerScore");
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}

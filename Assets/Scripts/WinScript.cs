using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    public TextMeshProUGUI pointsText;
    void Start()
    {   
        int playerScore = PlayerPrefs.GetInt("PlayerScore");
        pointsText.text = playerScore.ToString() + " POINTS";
    }
    public void nextLevelButton() {
        string previousSceneName = PlayerPrefs.GetString("previuScene");   

        switch (previousSceneName) {
            case "Level-1":
                SceneManager.LoadScene("Level-2");
                break;
            
            case "Level-2":
                SceneManager.LoadScene("Level-3");
                break;

            case "Level-3":
                SceneManager.LoadScene("Level-4");
                break;

            case "Level-4":
                SceneManager.LoadScene("Level-5");
                break;

            case "Level-5":
                SceneManager.LoadScene("MainMenu");
                break;

        }
    }

    public void mainMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}

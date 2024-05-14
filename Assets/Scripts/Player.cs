using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public GameObject Canva;
    public float timeStart = 0;
    public GameObject text;
    private int score;
    void Start()
    {
        UIManager timer  = Canva.GetComponent<UIManager>();

        Invoke("timer", timeStart);
        
        timer.getTime(timeStart);

        Scene scene = SceneManager.GetActiveScene();

        PlayerPrefs.SetString("previuScene", scene.name);
        PlayerPrefs.Save();

    }
    public void addScore(int points) {
        UIManager textScore  = text.GetComponent<UIManager>();
        score += points;
        textScore.updateScore(score);
    }

}


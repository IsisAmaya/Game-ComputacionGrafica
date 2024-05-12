using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float timeStart; 
    
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    public int maxScore;
    [SerializeField]
    private Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + 0;
        timeText.text = "Time: " + timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        timeText.text = "Time: " + Math.Round(timeStart).ToString();
        if (Math.Round(timeStart) <= 0) {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void updateScore(int playerScore) {
        scoreText.text =  "Score: " + playerScore.ToString();
        PlayerPrefs.SetInt("PlayerScore", playerScore);
        PlayerPrefs.Save();
    }

    public float getTime(float time) {
        timeStart = time;
        return timeStart;
    }

}

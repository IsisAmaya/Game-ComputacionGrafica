using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public GameObject Canva;
    public float timeStart = 20;
    public GameObject text;
    private int score;
    void Start()
    {
        UIManager timer  = Canva.GetComponent<UIManager>();
        timeStart =  20;

        Invoke("timer", timeStart);
        
        timer.getTime(timeStart);

    }
    public void addScore(int points) {
        UIManager textScore  = text.GetComponent<UIManager>();
        score += points;
        textScore.updateScore(score);
    }

}


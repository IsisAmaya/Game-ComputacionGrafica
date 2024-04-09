using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject text;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(int points) {
        UIManager textScore  = text.GetComponent<UIManager>();
        score += points;
        textScore.updateScore(score);
    }

}


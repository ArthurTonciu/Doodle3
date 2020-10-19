using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using System;

public class score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text HighScoreRound;
    public int HighScoreInt;
    
    
    

    void Start()
    {
        
        
    }
    

    void Update()
    {
        scoreText.text = player.position.y.ToString("0"); // наш scorе равен позиции игрока по оси y
        HighScoreRound.text = scoreText.text;
        HighScoreInt = int.Parse(scoreText.text);
        if (PlayerPrefs.GetFloat("highscore") < HighScoreInt)   // сохраняем скор только при условии , что новый счет больше сохраненого скора 
        {
            PlayerPrefs.SetFloat("highscore", HighScoreInt);
        }
    }
}

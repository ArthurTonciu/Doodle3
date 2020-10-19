using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;

    void Start()
    {
        highscoreText.text = "BEST SCORE : " + ((int)PlayerPrefs.GetFloat("highscore")).ToString();   // добавляем score из PlayerPrefs ( highscore )
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    // кнопка play . Запускает 1 уровень 
    }

    public void QuitGame()
    {
        Application.Quit();   // кнопка выхода на главном меню ( выключена в инстепкторе  )
    }
}

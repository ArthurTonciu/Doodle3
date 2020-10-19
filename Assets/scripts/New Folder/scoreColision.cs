using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreColision : MonoBehaviour
{
    public int count;
    public Text score_Text;
    public GameObject Ball;



    
    void Start()
    {
        score_Text = GameObject.Find("Score").GetComponent<Text>();
        Ball = GameObject.Find("player");
    }

    


    void Update()
    {
        score_Text.text = count.ToString();
    }


    public void OnCollisionEnter2D(Collision2D Ball)           // столкновения
    {
        if (Ball.relativeVelocity.y < 0)                       // если относительная скорость меньше 0, ну вниз летит короче
        {
            count++;
        }
    }
}

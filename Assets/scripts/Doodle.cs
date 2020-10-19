using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;                          // для перезагрузки уровня 
using UnityEngine.UI;

public class Doodle : MonoBehaviour
{
    public static Doodle instance;                          // это штучка нужна, чтобы мы могли использовать переменные в этом скрипте в других скриптах

    public GameObject DeadMenuUI;

    float horizontal;                                       // переменная для акселерометра
    public Rigidbody2D DoodleRigid;                         // публичный RB для дудлика
    public GameObject player;
    public Text score;
    public GameObject pauseButton;
    

    void Start()
    {
        if (instance == null)                               // теперь можно корректно использовать переменные в других скриптах
        {
            instance = this;                               
        }
        Time.timeScale = 1f;
    }

    
    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)    // если платформа Андроид
        {
            horizontal = Input.acceleration.x;                  // то подключаем акселерометр по оси х
        }

        if (Input.acceleration.x < 0)                           // если наклон акселерометра меньше нуля
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;    // то объект поворачивается налево
        }

        if (Input.acceleration.x > 0)                           // если наклон акселерометра больше нуля
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;     // то объект поворачивется направо
        }

        DoodleRigid.velocity = new Vector2(Input.acceleration.x * 11f, DoodleRigid.velocity.y);     //  добавляем силу к акселерометру, чтоб он не просто разворачивался в разные стороны
    }

    public void OnCollisionEnter2D(Collision2D collision)       // столкновение объекта
    {
        if (collision.collider.name == "DeadZone")              // если дудлик сталкивается с объектом с именем "DeadZone"
        {
            DeadMenuUI.SetActive(true);
            Time.timeScale = 0f;
            player.SetActive(false);
            score.enabled = false;
            pauseButton.SetActive(false);
            

        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(1);                          // перезагружаем 1 уровень . уровень 0 это меню 
    }
}


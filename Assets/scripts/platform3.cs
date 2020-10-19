using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class platform3 : MonoBehaviour
{ 
    public GameObject platform;
    public Rigidbody2D platformbody;
    public GameObject player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            if (collision.relativeVelocity.y < 0)
            {
                platformbody.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; // меняем тип RB , чтобы платформа полетела вниз 
            }
        }
    }





    public void OnCollisionExit2D(Collision2D collision)            // столкновения (ну только это когда оно заканчивается)
    {
        if (collision.collider.name == "DeadZone")                  // если платформа встретилась с объектом с именем DeadZone
        {
            
            float RandX = Random.Range(-1.9f, 1.9f);                // то задаем новую позицию по х
            float RandY = Random.Range(transform.position.y + 24f, transform.position.y + 24f); // и новую позицию по у
            platformbody.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;  // возвражаем тип RB , чтобы платформа перестала падать 

            transform.position = new Vector3(RandX, RandY, 0);      // перемещаем объект по заданным координатам
        }
    }
}

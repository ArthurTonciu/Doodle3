﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float forceJump;
    float dirX, moveSpeed = 2f;
    bool moveRight = true;

    public void OnCollisionEnter2D(Collision2D collision)           // столкновения
    {
        if (collision.relativeVelocity.y < 0)                       // если относительная скорость меньше 0, ну вниз летит короче
        {
            Doodle.instance.DoodleRigid.velocity = Vector2.up * forceJump;  // добавляем прыжок к переменной из скрипта "Doodle"
        }
    }


    public void Update()
    {
        if (transform.position.x > 2.1f)
            moveRight = false;
        if (transform.position.x < -2.1f)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);  
    }



    public void OnCollisionExit2D(Collision2D collision)            // столкновения (ну только это когда оно заканчивается)
    {
        if (collision.collider.name == "DeadZone")                  // если платформа встретилась с объектом с именем DeadZone
        {
            float RandX = Random.Range(-1.9f, 1.9f);                // то задаем новую позицию по х
            float RandY = Random.Range(transform.position.y + 24f, transform.position.y + 24f); // и новую позицию по у

            transform.position = new Vector3(RandX, RandY, 0);      // перемещаем объект по заданным координатам
        }
    }

}

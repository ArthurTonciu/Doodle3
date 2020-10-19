using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTrigger : MonoBehaviour
{
    public int count;
    public Text score_Text;


    void Start()
    {
        
    }

    


    void Update()
    {
        score_Text.text = count.ToString();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.position.y<0)
        {
            count++;
        }
    }

}

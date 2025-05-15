using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform ball; 
    public float speed = 5f; 
    public float followThreshold = 0.5f; 

    void Update()
    {
        
        if (Mathf.Abs(ball.position.y - transform.position.y) > followThreshold)
        {
        
            if (ball.position.y > transform.position.y)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
           
            else if (ball.position.y < transform.position.y)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
    }
}
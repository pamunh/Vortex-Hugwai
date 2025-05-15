using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed; 
    public bool ground = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool facinRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        ground = Physics2D.Linecast(groundCheck.position, transform.position,groundLayer);
        Debug.Log(ground);

        if(ground == false)
        {
            speed *=  -1;
        }

        if (speed > 0 && !facinRight)
        {
            Flip();
        }
        else if(speed < 0 && facinRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        facinRight = !facinRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           collision.gameObject.GetComponent<PlayerLife>().LoseLife();
           
        }
    }
}

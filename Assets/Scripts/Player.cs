using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

public class Player : MonoBehaviour
{
    public float speed; // Velocidade de movimento do jogador
 

    Animator anim;
    Rigidbody2D rb;
 

    bool estaEncostandoNaParede = false;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }
    void FixedUpdate()
    {
       Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
 
       anim.SetFloat("Horizontal", move.x);
       anim.SetFloat("Vertical", move.y);
       anim.SetFloat("Speed", move.magnitude);

       rb.velocity = move * speed;
       transform.position = transform.position + move * speed * Time.deltaTime;
    }
}
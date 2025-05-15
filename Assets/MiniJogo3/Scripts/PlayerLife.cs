using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public bool alive = true;

    void Start()
    {
        // Inicialize o GameController
        if (GameController.gc == null)
        {
            Debug.LogError("GameController instance is null");
        }
    }

    void Update()
    {
        GameController.gc.RefreshScreen();
    }

    public void LoseLife()
    {
        if (alive == true)
        {
            alive = false;
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Player1>().enabled = false;
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            GameController.gc.SetLives(-1);
            
            if(GameController.gc.lives >= 0)
            {
                Invoke("LoadScene", 1f);
            }
            else
            {
                Invoke("LoadGameOver", 1f);
                GameController.gc.lives = 3;
            }
        }
    }
    void LoadGameOver()
    {
        SceneManager.LoadScene("GameOverMN3");
        GameController.gc.timeCount = 0;
        GameController.gc.lives = 0;
        GameController.gc.coins = 0;
        GameController.gc.RefreshScreen();
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Fase 3");
        GameController.gc.timeCount = 10;
        
    }
}


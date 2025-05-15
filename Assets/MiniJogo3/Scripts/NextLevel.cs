using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject player;
    public bool ultimaFase;
    public AudioClip finish;
    public AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.gc.textNextLevel.SetActive(true);
            GameObject.Find("MusicPlayer"). GetComponent<AudioSource>().Stop();
            player.SetActive(false);
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Animator>().SetBool("Walk", false);
            collision.GetComponent<Animator>().Play("Player_Idle");
            GetComponent<AudioSource>().clip = finish;
            GetComponent<AudioSource>().Play();
            Invoke("NextScenes", 5f);
        }
        
    }
    void NextScenes()
    {
        if(ultimaFase)
        {
            SceneManager.LoadScene("Menu");
            GameController.gc.textNextLevel.SetActive(false);
             GameController.gc.timeCount = 0;
             GameController.gc.lives = 0;
             GameController.gc.coins = 0;
             GameController.gc.RefreshScreen();
             GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameController.gc.textNextLevel.SetActive(false);
            GameController.gc.timeCount = 30f;
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Play();
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScene(string cena)
    {
        SceneManager.LoadScene(cena);
        GameController.gc.timeCount = 30;
        GameController.gc.lives = 3;
        GameController.gc.coins = 0;
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    
    public static GameController gc;
    public Text coinsText;
    public int coins;

    public Text lifeText;
    public int lives = 3;

    public Text timeText;
    public float timeCount;
    public bool timeOver = false;
    public GameObject textNextLevel;

    void Awake()
    {
        if(gc == null)
        {
            gc = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(gc != this)
        {
            Destroy(gameObject);
        }
        RefreshScreen();
    }
    private void Update()
    {
        TimeCount();
    }
    public void SetCoins(int coin)
    {
        coins += coin;
        if(coins >= 10)
        {
            coins = 0;
            lives += 1;
        }
        RefreshScreen();
    }
    public void SetLives(int life)
    {
        lives += life;
        if(lives >=0)
        RefreshScreen();
    }
    public void RefreshScreen()
    {
        coinsText.text = coins.ToString();
        lifeText.text = lives.ToString();
        timeText.text = timeCount.ToString("F0");
    }
    void TimeCount()
    {
        timeOver = false;

        if(timeOver && timeCount > 0)
        {
            timeCount -= Time.deltaTime;
            RefreshScreen();

            if(timeCount <= 0)
            {
                timeCount = 0;
                GameObject.Find("Player").GetComponent<PlayerLife>().LoseLife();
                timeOver = true;
            }
        }
    }
}
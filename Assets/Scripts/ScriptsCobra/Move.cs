using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] List<Transform> snakeBodies;
    [SerializeField] Transform body;

    Game gM;

    private void Start()
    {
        
        gM = FindObjectOfType<Game>();
        snakeBodies =  new List<Transform>();
        snakeBodies.Add(transform);

        gM.score = 0;
        gM.scoreText.text = "Score: 0";

        gM.hScore = PlayerPrefs.GetInt("HScore");
        gM.hscoreText.text = "H-Score: " + gM.hScore.ToString();
    }
    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float YAxis = Input.GetAxisRaw("Vertical");

        if(xAxis != 0)
           direction = Vector2.right * xAxis;
        if(YAxis != 0)
           direction = Vector2.up * YAxis;

    }
    private void FixedUpdate()
    {
        for (int i = snakeBodies.Count -1; i > 0; i--)
        {
            snakeBodies[i].position = snakeBodies[i -1].position;
        }

        MoveSnake();
    }
    void MoveSnake()
    {
        float roundPosX = Mathf.Round(transform.position.x);
        float roundPosY = Mathf.Round(transform.position.y);

        transform.position = new Vector2(roundPosX + direction.x, roundPosY + direction.y);
    }
    void GrowingSnake()
    {
        Transform SpawnBody = Instantiate(body, snakeBodies[snakeBodies.Count -1].position, Quaternion.identity);
        snakeBodies.Add(SpawnBody);
        gM.SetScore(10);
    }
    public void BtnStartGame()
    {
        gM.gameOverPanel.SetActive(false);
        gM.StartPanel.SetActive(false);
        Time.timeScale = 1;
        transform.position = Vector2.zero;
        direction = Vector2.zero;

        for (int i = 1; i < snakeBodies.Count; i++)
        {
            Destroy(snakeBodies[i].gameObject);
        }
        snakeBodies.Clear();
        snakeBodies.Add(transform);

        gM.score = 0;
        gM.scoreText.text = "Score: 0";

        gM.hScore = PlayerPrefs.GetInt("HScore");
        gM.hscoreText.text = "H-Score: " + gM.hScore.ToString();


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {

            case "Food":
            GrowingSnake();
            break;
            case "Obstacles":
            gM.GameOver();
            break;
        }
    }

}

using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]private TMP_Text paddle1ScoreText;
    [SerializeField]private TMP_Text paddle2ScoreText;

    [SerializeField]private Transform paddle1Transform;
    [SerializeField]private Transform paddle2Transform;
    [SerializeField]private Transform ballTransform;

    private int paddle1Score;
    private int paddle2Score;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();

            }
            return instance;
        }
    }

    public void Paddle1Scored()
    {
        paddle1Score++;
        paddle2ScoreText.text = paddle1Score.ToString();
    }

    public void Paddle2Scored()
    {
        paddle2Score++;
        paddle1ScoreText.text = paddle2Score.ToString();
    }

    public void Restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }


}

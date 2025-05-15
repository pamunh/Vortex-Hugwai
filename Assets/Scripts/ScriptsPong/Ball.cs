using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ballRb;
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }
    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }
    private void OnColliderEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Paggle"))
        {
            ballRb.velocity *= velocityMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal1"))
        {
            GameManager.Instance.Paddle2Scored();
            GameManager.Instance.Restart();
            Launch();
        }
        else
        {
            GameManager.Instance.Paddle1Scored();
            GameManager.Instance.Restart();
            Launch();
        }

    }
  
}

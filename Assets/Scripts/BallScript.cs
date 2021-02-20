using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{

    private float speed = 300;
    private int scoreCountPlayerLeft;
    private int scoreCountPlayerRight;
    public Text scorePlayerLeft;
    public Text scorePlayerRight;

    private int INCREASE_BALL_SPEED = 50;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;
    }

    void OnCollisionEnter2D(Collision2D collosion)
    {
        // detects which player hits the ball
        if(collosion.gameObject.name.Equals("PlayerLeft"))
        {
            // contact with PlayerRight
            float y = hitObject(transform.position, collosion.transform.position, collosion.collider.bounds.size.y);
            // calculate direction
            Vector2 direction = new Vector2(1, y);

            IncreaseBallSpeedBy(INCREASE_BALL_SPEED);
            // apply direction-vector on physics
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }        
        if(collosion.gameObject.name.Equals("PlayerRight"))
        {
            // contact with PlayerRight
            float y = hitObject(transform.position, collosion.transform.position, collosion.collider.bounds.size.y);
            // calculate direction
            Vector2 direction = new Vector2(1, y);
            IncreaseBallSpeedBy(INCREASE_BALL_SPEED);
            // apply direction-vector on physics
            GetComponent<Rigidbody2D>().velocity = direction * speed;

        }        
        if(collosion.gameObject.name.Equals("GoalLeft"))
        {
            scoreCountPlayerRight++;
            scorePlayerRight.text = scoreCountPlayerRight.ToString();
            Restart();
        }        
        if(collosion.gameObject.name.Equals("GoalRight"))
        {
            scoreCountPlayerLeft++;
            scorePlayerLeft.text = scoreCountPlayerLeft.ToString();
            Restart();
        }
    }

    private void StartBall(float speed)
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * x, speed * y);
    }

    private float hitObject(Vector2 ballPosition, Vector2 playerPosition, float playerHight)
    {
        return (ballPosition.y - playerPosition.y) / playerHight;
    }
    
    private void IncreaseBallSpeedBy(int increasedBy)
    {
        speed += increasedBy;
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;
    }

    private void Restart()
    {
        Vector2 startPosition = transform.position;
        startPosition.x = 408.5F; 
        startPosition.y = 177.45F;
        gameObject.transform.position = startPosition;
        
        speed = 250;
        StartBall(speed);
    }
}

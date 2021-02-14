using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{

    public float speed;
    private int scoreCountPlayerLeft;
    private int scoreCountPlayerRight;
    public Text scorePlayerLeft;
    public Text scorePlayerRight;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;

        //float x = Random.Range(0, 2) == 0 ? -1 : 1;
        //float y = Random.Range(0, 2) == 0 ? -1 : 1;
        //GetComponent<Rigidbody2D>().velocity = new Vector2(speed * x, speed * y);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            // apply direction-vector on physics
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }        
        if(collosion.gameObject.name.Equals("PlayerRight"))
        {
            // contact with PlayerRight
            float y = hitObject(transform.position, collosion.transform.position, collosion.collider.bounds.size.y);
            // calculate direction
            Vector2 direction = new Vector2(1, y);
            // apply direction-vector on physics
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }        
        if(collosion.gameObject.name.Equals("GoalLeft"))
        {
            scoreCountPlayerRight++;
            scorePlayerRight.text = scoreCountPlayerRight.ToString();
            Start();
        }        
        if(collosion.gameObject.name.Equals("GoalRight"))
        {
            scoreCountPlayerLeft++;
            scorePlayerLeft.text = scoreCountPlayerLeft.ToString();
            Restart();

        }
    }

    private float hitObject(Vector2 ballPosition, Vector2 playerPosition, float playerHight)
    {
        return (ballPosition.y - playerPosition.y) / playerHight;
    }

    private void Restart()
    {
        //Vector2 startPosition = Vector2.zero;
        //gameObject.transform.position = startPosition;

        //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = startPosition;
    }
}

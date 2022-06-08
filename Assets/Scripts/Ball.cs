using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private int direction = -1;
    private int yDirection = -1;
    private Vector2 vel;
    public float speedY = 0.01f;
    public float speedX = 0.01f;
    public bool newGame;
    private GameManager manager;
    private float playerVel = 0;
    public float angleMultiplier = 10;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(0, 2) * 2 - 1;
        yDirection = Random.Range(0, 2) * 2 - 1;
        /*
        if(Random.Range(-1,1) >= 0)
        {
            direction = 1;
        }
        if (Random.Range(-1, 1) >= 0)
        {
            yDirection = 1;
        }
        */
        speedY = Random.Range(0, speedX / 10) * yDirection;
        newGame = true;
        vel = new Vector2(speedX * direction, speedY);

        


    }

    // Update is called once per frame
    void Update()
    {

        if (manager.isNewGame())
        {
            rb.AddForce(vel, ForceMode2D.Impulse);
            newGame = false;
        }
        /*
        Debug.Log("Velocity Y: " + rb.velocity.y);
        Debug.Log("Velocity X: " + rb.velocity.x);
        */

        rb.velocity = speedX * vel;
        //Debug.Log("YVelocity" + vel.y);
        //Debug.Log("Speed" + speedX);



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        yDirection *= -1;
        if (!collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Hit Wall");

            vel = new Vector2(speedX * direction, speedY * yDirection);
        }
        else
        {
            direction *= -1;
            Debug.Log("Hit Paddle");

            playerVel = (- collision.gameObject.GetComponent<Transform>().position.y + this.GetComponent<Transform>().position.y) * angleMultiplier;
            if (playerVel < 0)
            {
                yDirection = -1;
            }
            else
            {
                yDirection = 1;
            }
            speedY = Mathf.Abs(playerVel);
            //Debug.Log("Player Vel:" + playerVel);

            vel = new Vector2(speedX * direction, playerVel);
            //rb.AddForce(vel, ForceMode2D.Impulse);
        }
        Debug.Log("yDirection: " + yDirection);

    }

   
}

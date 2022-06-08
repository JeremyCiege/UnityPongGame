using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int pointsP1 = 0;
    public int pointsP2 = 0;
    public Text score1UI;
    public Text score2UI;
    public GameObject ball;
    public GameObject gameBounds;
    private bool newGame;
    GameObject gameball;
    private bool volley;
    private bool isCoroutineExecuting = false;


    // Start is called before the first frame update
    void Start()
    {

        newGame = true;
        volley = false;
        pointsP1 = 0;
        pointsP2 = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (newGame && !volley)
        {
            new WaitForSeconds(50);
            gameball = Instantiate(ball);
            volley = true;
            newGame = false; 
        }
        Debug.Log("NewGame? : " + newGame);
        */
        
        if (!volley)
        {
            
            StartCoroutine(ExampleCoroutine());
            volley = true;
            //wait a couple seconds and reset the pins

        }







    }

    public void scoreP1()
    {
        pointsP1++;
        score1UI.text = pointsP1.ToString();
        StartCoroutine(wait(50));
        volley = false;
    }

    public void scoreP2()
    {
        pointsP2++;
        score2UI.text = pointsP2.ToString();
        StartCoroutine(wait(50));
        volley = false;
    }


    public void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    public bool isNewGame()
    {
        return newGame;
    }

    IEnumerator wait(float seconds)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(seconds);

        isCoroutineExecuting = false;

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
    }

    IEnumerator ExampleCoroutine()
    {
        

        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        
            gameball = Instantiate(ball);
        
        

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

}

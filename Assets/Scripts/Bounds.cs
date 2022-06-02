using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Transform>().position.x > 0)
        {
            manager.scoreP1();
        }
        else
        {
            manager.scoreP2();

        }

        Destroy(collision.gameObject);


    }

}

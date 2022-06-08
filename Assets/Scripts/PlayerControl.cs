using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 move = new Vector2(0, movementInput.y);

        Debug.Log("Movement Input: " + movementInput.y);
        if (movementInput.y > 0)
        {
            rb.velocity = speed * move;

        }
        else if(movementInput.y < 0)
        {
            rb.velocity = speed * move;

        }
        else
        {
            rb.velocity = Vector2.zero;
        }




    }

    private Vector2 movementInput = Vector2.zero;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

    }
    
        
    


}

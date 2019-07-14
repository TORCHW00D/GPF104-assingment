using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Controls : MonoBehaviour
{
    //Movement Vars
    public float moveSpeed = 5.0f;
    public float playerHealth = 100.00f;
    public int jumpsLeft = 2;
    private Rigidbody2D PlayerChar;


    

    // Start is called before the first frame update
    void Start()
    {
        PlayerChar = gameObject.GetComponent<Rigidbody2D>();
        if (PlayerChar == null)
        {
            Debug.LogError("PLAYER: can't find rigidbody");
        }
    }
        
    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

        //LookAtMyMouse();
        float horizontalMovement = 0.0f;
        float verticalMovement = 0.0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalMovement = -moveSpeed * 20 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMovement = moveSpeed * 20 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalMovement = moveSpeed * 20 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalMovement = -moveSpeed * 20 * Time.deltaTime;
        }

        Vector2 movementDirection = new Vector2(horizontalMovement, verticalMovement);
        PlayerChar.AddForce(movementDirection);


    }
}

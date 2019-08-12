using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player2Controls : MonoBehaviour
{
    //Movement Vars
    public float moveSpeed = 5.0f;
    public float playerHealth = 50.00f;
    public int jumpsLeft = 2;
    public Slider HealthBar;

    private Vector3 StartPosition;
    private Rigidbody2D PlayerChar;
    private float horizontalMovement = 0.0f;
    private float verticalMovement = 0.0f;
    private Vector2 movementDirection;


    // Start is called before the first frame update
    void Start()
    {
        PlayerChar = gameObject.GetComponent<Rigidbody2D>();
        if (PlayerChar == null)
        {
            Debug.LogError("PLAYER: can't find rigidbody");
        }
        StartPosition = transform.position;
        HealthBar.value = playerHealth;
    }
        
    public void TakeDamage(float damage)
    {
        HealthBar.value = playerHealth;
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            moveToStart();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            Debug.Log("hit death zone!");
            moveToStart();
        }

    }

    

    public void moveToStart()
    {
        transform.position = StartPosition;
    } 

    // Update is called once per frame
    void Update()
    {

        //LookAtMyMouse();
       

        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift)))
        {
            horizontalMovement = -moveSpeed * 30 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift)))
        {
            horizontalMovement = moveSpeed * 30 * Time.deltaTime;
        }
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    verticalMovement = moveSpeed * 20 * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    verticalMovement = -moveSpeed * 20 * Time.deltaTime;
        //}

        movementDirection = new Vector2(horizontalMovement, verticalMovement);
        verticalMovement = 0;
        horizontalMovement = 0;
    }
    private void FixedUpdate()
    {
        PlayerChar.AddForce(movementDirection);
    }
}

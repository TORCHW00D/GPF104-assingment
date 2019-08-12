using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public LayerMask ground;

    public float moveSpeed = 5.0f;
    public float playerHealth = 100.00f;
    public int jumpsLeft = 2;
    public Slider HealthBar;

    private int _jumpsLeft;
    private bool onGround;
    private Rigidbody2D PlayerChar;
    private Vector3 StartPos;
    private float horizontalMovement = 0.0f;
    private float verticalMovement = 0.0f;
    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        //_jumpsLeft = jumpsLeft;
        PlayerChar = gameObject.GetComponent<Rigidbody2D>();
        if (PlayerChar == null)
        {
            Debug.LogError("PLAYER: can't find rigidbody");
        }
        StartPos = transform.position;
        HealthBar.value = playerHealth;
    }

    public void TakeDamage(float damage)
    {
        HealthBar.value = playerHealth;
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            moveToStart();
            playerHealth = 100.0f;
        }
    }

    public void moveToStart()
    {
        transform.position = StartPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            //Debug.Log("hit death zone!");
            moveToStart();
        }
        if (collision.gameObject.tag == "EndPractice")
        {
            Debug.Log("Level completed!!");
            SceneManager.LoadScene("Level1");
        }
        if (collision.gameObject.tag == "EndLvl1")
        {
            Debug.Log("Level completed!!");
            SceneManager.LoadScene("Level2");
        }
        if (collision.gameObject.tag == "EndLvl2")
        {
            Debug.Log("Level completed!!");
            SceneManager.LoadScene("Level3");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ground")
        {
            //Debug.Log("Touched ground! " + _jumpsLeft);
            onGround = true;
            if (onGround)
            {
               // Debug.Log(_jumpsLeft + " " + onGround);
                _jumpsLeft = jumpsLeft;
            } else
            {
               // Debug.Log("Not grounded!");
            }
            onGround = false;
        }     
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.LeftShift)))
        {
            horizontalMovement = -moveSpeed * 20 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.LeftShift)))
        {
            horizontalMovement = moveSpeed * 20 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_jumpsLeft > 0)
            {
                PlayerChar.velocity += new Vector2(0, moveSpeed/3);
               // Debug.Log(_jumpsLeft + " / " + jumpsLeft);
                _jumpsLeft--;
               // Debug.Log(_jumpsLeft + " / " + jumpsLeft + " post index");
            }
            else
            {
               // Debug.Log("No Jumps left!");
            }

        } else
        {
            verticalMovement = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            verticalMovement = -moveSpeed * 1500 * Time.deltaTime;
        }
        //print(GetComponent<Rigidbody2D>().velocity);
        if (GetComponent<Rigidbody2D>().velocity.y < -1f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-25));
        }
        movementDirection = new Vector2(horizontalMovement, verticalMovement);
        horizontalMovement = 0;
        verticalMovement = 0;

        onGround = false;
        
    }
    private void FixedUpdate()
    {
        PlayerChar.AddForce(movementDirection);
    }
}

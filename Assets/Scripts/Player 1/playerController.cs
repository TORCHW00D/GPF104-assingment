using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public LayerMask ground;

    public float moveSpeed = 5.0f;
    public float playerHealth = 100.00f;
    public int jumpsLeft = 2;
    private int _jumpsLeft;
    private bool onGround;
    private Rigidbody2D PlayerChar;


    // Start is called before the first frame update
    void Start()
    {
        //_jumpsLeft = jumpsLeft;
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
    void FixedUpdate()
    {
        float horizontalMovement = 0.0f;
        float verticalMovement = 0.0f;
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMovement = -moveSpeed * 20 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalMovement = moveSpeed * 20 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_jumpsLeft > 0)
            {
                verticalMovement = moveSpeed * 500 * Time.deltaTime;
               // Debug.Log(_jumpsLeft + " / " + jumpsLeft);
                _jumpsLeft--;
               // Debug.Log(_jumpsLeft + " / " + jumpsLeft + " post index");
            }
            else
            {
               // Debug.Log("No Jumps left!");
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            verticalMovement = -moveSpeed * 1500 * Time.deltaTime;
        }

        Vector2 movementDirection = new Vector2(horizontalMovement, verticalMovement);
        PlayerChar.AddForce(movementDirection);

        onGround = false;
        
    }
}

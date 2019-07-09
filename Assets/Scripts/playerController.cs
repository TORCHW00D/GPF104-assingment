using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//touch class
public class playerController : MonoBehaviour
{
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

    // Update is called once per frame
    void FixedUpdate()
    {
        int _jumpsLeft = jumpsLeft;
        bool onGround = false;
        float horizontalMovement = 0.0f;
        float verticalMovement = 0.0f;

        if (onGround)
        {

        }


        if (Input.GetKey(KeyCode.A))
        {
            horizontalMovement = -moveSpeed * 20 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalMovement = moveSpeed * 20 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _jumpsLeft >= 1)
        {
            verticalMovement = moveSpeed * 500 * Time.deltaTime;
            _jumpsLeft--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            verticalMovement = -moveSpeed * 1500 * Time.deltaTime;
        }

        Vector2 movementDirection = new Vector2(horizontalMovement, verticalMovement);
        PlayerChar.AddForce(movementDirection);


    }
}

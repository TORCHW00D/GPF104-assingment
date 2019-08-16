﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player1")
        {
            Debug.Log("Level completed!!");
            SceneManager.LoadScene("MAIN MENU");
        }
    }

}
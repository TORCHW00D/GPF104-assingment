﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTransit3 : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Level completed!!");
            SceneManager.LoadScene("Level3");
        }
    }

}

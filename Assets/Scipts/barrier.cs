using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="enemy1"||collision.gameObject.tag=="enemy2"){
            playerUI.instance.GameOver();
        }
    }
}

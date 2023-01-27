using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    float timer = 0;
    GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        transform.Translate(new Vector3(0,-2*Time.deltaTime,0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player"){
            playerUI.instance.UpdateLives();
            player = collision.gameObject;
            player.GetComponent<Renderer>().material.color = Color.red;
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag =="bullet"){
            playerUI.instance.UpdateScore(1);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag =="barrier"){
            Destroy(gameObject);
        }
    }
}

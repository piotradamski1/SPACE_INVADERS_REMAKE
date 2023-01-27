using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        transform.Translate(new Vector3(0,-4*Time.deltaTime,0));
        if(timer>3f){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="enemy1"){
            playerUI.instance.UpdateScore(5);
        }
        else if(collision.gameObject.tag=="enemy2"){
            playerUI.instance.UpdateScore(20);
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}

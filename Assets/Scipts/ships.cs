using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ships : MonoBehaviour
{
    float timer = 0;
    float direction = 1;
    int counter = 0;
    bool done = false;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(counter<10){
            if(timer > 1f){
                if(tag == "enemy2"){
                    Move(0.25f,0);
                }
                done = false;
                counter++;
                timer = 0;
            }
            if(timer > 0.75f){
                if(tag=="enemy1" && !done){
                    Move(0.25f,0);
                }
                done=true;
            }
        }
        else if(counter==10){
            Move(0,-0.25f);
            counter=0;
            direction*=-1;
        }
    }
    void Move(float horiz, float vert){
        transform.Translate(new Vector3(direction*horiz,vert,0));
    }
}

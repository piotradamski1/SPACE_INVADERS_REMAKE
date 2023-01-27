using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplay : MonoBehaviour
{
    [SerializeField]
    private GameObject playerMissile;
    [SerializeField]
    private GameObject enemyMissile;
    [SerializeField]
    private AudioSource laserSound;
    private Transform randomShip;
    float timer = 0;
    int shipNum;
    void Start()
    {
        InvokeRepeating("EnemyShooting",0.1f,2f);
        Time.timeScale = 1;
    }
    void Update()
    {   
        timer+=Time.deltaTime;
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(new Vector3(4*Time.deltaTime,0,0));
        }
        else if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(new Vector3(-4*Time.deltaTime,0,0));
        }
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)){
            if(timer>1f){
                Instantiate(playerMissile, new Vector3(transform.position.x, transform.position.y+0.6f, 0), transform.rotation);
                laserSound.Play();
                timer=0;
            }
        }
    }
    void EnemyShooting(){
        if(GameObject.Find("enemy_row1").transform.childCount!=0){
            shipNum = Random.Range(0, GameObject.Find("enemy_row1").transform.childCount);
            randomShip = GameObject.Find("enemy_row1").transform.GetChild(shipNum);
            Instantiate(enemyMissile, new Vector3(randomShip.position.x, randomShip.position.y-0.3f, 0), randomShip.rotation);
        }
        else{
            CancelInvoke("EnemyShooting");
        }
        if(GetComponent<Renderer>().material.color == Color.red){
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="enemy1"||collision.gameObject.tag=="enemy2"){
            playerUI.instance.GameOver();
            Destroy(collision.gameObject);
        }
    }
}

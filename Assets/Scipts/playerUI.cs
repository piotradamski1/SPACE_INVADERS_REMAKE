using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerUI : MonoBehaviour
{
    public static playerUI instance;
    [SerializeField]
    private Text scoreUI;
    [SerializeField]
    private Text finalScoreUI;
    [SerializeField]
    private Text livesUI;
    [SerializeField]
    private AudioSource deadSound;
    [SerializeField]
    private AudioSource scoreSound;
    int score = 0, lives = 3;
    string nick = "Guest";
    int winShipsLeft = 36;
    List<KeyValuePair<string, int>> rankingList = new List<KeyValuePair<string, int>>();

    void Awake()
    {
        instance = this;
    }
    public void UpdateScore(int points)
    {
        score+=points;
        scoreUI.text = "score: "+score.ToString("D4");
        scoreSound.Play();
        CheckIfWin(points);
    }
    public void CheckIfWin(int points){
        if(points!=1){
            winShipsLeft--;
                if (winShipsLeft==0){
                GameOver();
            }
        }
    }
    public void UpdateLives()
    {   
        lives--;
        livesUI.text = "lives: "+lives;
        if(lives==0){
            GameOver();
        }
        else{
            deadSound.Play();
        }
    }
    public void GameOver(){
        Time.timeScale = 0;
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
        finalScoreUI.text = "Score: "+score.ToString("D4");
        deadSound.Play();
    }
    public void ReadNickname(string s){
        nick = s;
    }
    public void Reload(){
        for(int i = 0; i<10; i++){
            if(PlayerPrefs.HasKey("nick"+i)){
                rankingList.Add(new KeyValuePair<string, int>(PlayerPrefs.GetString("nick"+i),PlayerPrefs.GetInt("score"+i)));
            }
        }
        rankingList.Add(new KeyValuePair<string, int>(nick, score));
        rankingList = (from entry in rankingList orderby entry.Value descending select entry).ToList();
        for(int i = 0; i<10; i++){
            if(rankingList.Count>i){
                PlayerPrefs.SetString(("nick"+i), rankingList[i].Key);
                PlayerPrefs.SetInt(("score"+i), rankingList[i].Value);
            }
        }
        SceneManager.LoadScene("Menu");
    }
}

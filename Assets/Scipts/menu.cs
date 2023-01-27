using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField]
    private Text boardUI;
    string rankingText = "";
    public void Awake(){
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
    public void Play(){
        SceneManager.LoadScene("Game");
    }
    public void Exit(){
        Debug.Log("Exit");
        Application.Quit();
    }
    public void ShowScoreBoard(){
        for(int i = 0; i<10; i++){
            if(PlayerPrefs.HasKey("nick"+i)){
                rankingText+=(i+1).ToString("D2")+". "+PlayerPrefs.GetString("nick"+i)+" - " +PlayerPrefs.GetInt("score"+i).ToString("D4") + "\n";
            }
            else{
                rankingText+=(i+1).ToString("D2")+". --- ---\n";
            }
        }
        boardUI.text = rankingText;
    }
     public void MuteToggle(bool muted){
        if(muted){
            AudioListener.volume = 0;
        }
        else{
            AudioListener.volume = 1;
        }
    }
}
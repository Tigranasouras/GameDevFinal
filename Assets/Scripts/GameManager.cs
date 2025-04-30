using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentLevel = 1;
    public int maxLevel = 3;
    public bool inCombat = false;

    private void Awake()
    {
        if(Instance == null){
        Instance = this;
        DontDestroyOnLoad(gameObject); // persist between scenes
        }else{
        Destroy(gameObject);
    }


    }

    public void StartGame(){
        currentLevel = 1;
        LoadGame();
    }

    public void LoadGame(){
        inCombat = true;
        SceneManager.LoadScene("gameplay");
    }

    public void LoadSacrifice()
    {
        inCombat = false;
        SceneManager.LoadScene("Sacrifice");     
    }

    public void NextLevel()
    {      
    currentLevel++;
    if(currentLevel > maxLevel){
    LoadVictory();
    }else{
    LoadSacrifice();
    }
    }

    public void LoadVictory(){
        SceneManager.LoadScene("VictoryScene");
    }
}

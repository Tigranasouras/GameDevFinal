using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CultManager : MonoBehaviour
{

    public static CultManager Instance;

    public int cultistCount = 0;

    public Text cultistUIText;


    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    public void AddCultists(int amount)
    {
        cultistCount += amount;
        UpdateCultistsUI();
    }


    public bool SpendCultists(int amount)
    {
        if(cultistCount >= amount)
        {
            cultistCount -= amount;
            UpdateCultistsUI();
            return true;

        }
        return false;
    }

    public void ResetCultists()
    {
        cultistCount = 0;
        UpdateCultistUI();
    }

    private void UpdateCultistUI()
    {
        if(cultistUIText != null)
        {
            cultistUIText.text = "Cultists: " + cultistCount;
        }
    }


  
}

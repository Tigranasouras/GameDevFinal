using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemy : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;
    public Slider healthBar;

    public Slider enemyHealthBar;

    public int cultistReward = 5;

    public int damagePerClick = 13;

    public Text WinTextUI;

     public float damageInterval = 0.3f;

     public int clickDamage = 26;

     public TMPro.TextMeshProUGUI crabHealth;
     public TMPro.TextMeshProUGUI playerHealth;

     public GameObject resetButton;




    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        InvokeRepeating(nameof(dealDamage), 0f, damageInterval);
        
    }

    private void Update()
    {
      if (Input.GetMouseButtonDown(0) && healthBar.value > 0 && enemyHealthBar.value > 0|| Input.GetKeyDown(KeyCode.Space)  && healthBar.value > 0 && enemyHealthBar.value > 0){
        
     TakeDamage(clickDamage);

            
    }   
    }




    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if(currentHealth <= 0){
            Die();
        }

    }



    private void UpdateHealthUI()
    {
        if(healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
            playerHealth.text = "" + healthBar.value;
        }
    }

    private void dealDamage(){

        if(enemyHealthBar != null){
            enemyHealthBar.value -= damagePerClick;
            crabHealth.text = "" + enemyHealthBar.value;
        }

        if (healthBar.value <= 0)
            {
                healthBar.value = 0;
                 UpdateLoseUI();
                CancelInvoke(nameof(dealDamage)); // Stop future damage calls
                resetButton.gameObject.SetActive(true);
            }

        if(enemyHealthBar.value <=0){
            enemyHealthBar.value = 0;
            UpdateLoseUI();
            CancelInvoke(nameof(dealDamage));
            resetButton.gameObject.SetActive(true);
        }

    
    }


    private void Die()
    {
        UpdateWINUI();
        //Reward Cultists for defeating enemy
        //CultManager.Instance.AddCultists(cultistReward);
        //tell GameManager to go to next phase
        //GameManager.Instance.NextLevel(); 

    }

    private void UpdateWINUI()
    {
        if(WinTextUI != null)
        {
            WinTextUI.text = "YOU WIN";
        }
    }

    private void UpdateLoseUI()
    {
        if(WinTextUI != null)
        {
            WinTextUI.text = "GAME OVER";
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemy : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;
    public Slider healthBar;

    public int cultistReward = 5;

    public int damagePerClick = 10;


    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
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
        }
    }


    private void Die()
    {
        //Reward Cultists for defeating enemy
        CultManager.Instance.AddCultists(cultistReward);
        //tell GameManager to go to next phase
        GameManager.Instance.NextLevel(); 

    }


}

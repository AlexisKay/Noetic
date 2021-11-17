using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats {
        public int maxHealth = 100;
        public int maxStamina = 100;
        public int currentHealth;
        public int currentStamina;
    }

    public PlayerStats playerStats = new PlayerStats();
    public PlayerLife playerLife;
    public int fallBoundary = -20;
    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public PlayerAttack playerAttack;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        playerStats.currentHealth = playerStats.maxHealth;
        playerStats.currentStamina = playerStats.maxStamina;

        healthBar.SetMaxHealth(playerStats.maxHealth);
        staminaBar.SetMaxStamina(playerStats.maxStamina);
    }

    public void LoseStamina(int temp) {
        //func to decrease use in stamina

        //lose it
        playerStats.currentStamina -= temp;
        staminaBar.SetStamina(playerStats.currentStamina);

        //then regen it
        if (regen != null) { StopCoroutine(regen); }
        regen = StartCoroutine(RegenStamina());

    }

    private IEnumerator RegenStamina() {
        //wait 2 seconds until continue
        yield return new WaitForSeconds(2);

        while (playerStats.currentStamina < playerStats.maxStamina) {
            playerStats.currentStamina += 3;
            staminaBar.SetStamina(playerStats.currentStamina);
            yield return regenTick;
        }
        
        //regen = null;
    }

    void Update()
    {
        //if (Input.GetKeyDown (KeyCode.Space)) {
        //	score.scoreValue += 10;
        //} 
        //if (Input.GetKeyDown (KeyCode.Mouse0)) {
        //	TakeDamage (5);
        //} 

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            LoseStamina(5);
        }
       
    }


    public void TakeDamage(int damage)
    {
        playerStats.currentHealth -= damage;
        healthBar.SetHealth(playerStats.currentHealth);
        anim.SetBool("hurt", true);
        Debug.Log("current health: " + playerStats.currentHealth);
        
        if (playerStats.currentHealth <= 0)
        {
            playerLife.Die();
            Debug.Log("YOU DIED");

        }
    }

    public void NoLongerHurt() {
        anim.SetBool("hurt", false);
    }

    public void Heal(int heal)
    {
        if (playerStats.currentHealth < 100)
        {
            playerStats.currentHealth += heal;
            healthBar.SetHealth(playerStats.currentHealth);
            Debug.Log("Healed for " + heal + "Current Health: " + playerStats.currentHealth);
        }
        if (playerStats.currentHealth > 100)
        {
            int extraHealth = playerStats.currentHealth - 100;
            playerStats.currentHealth = playerStats.currentHealth - extraHealth;
        }

    }

}


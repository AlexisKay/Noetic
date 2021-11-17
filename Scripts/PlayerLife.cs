using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Player player;
    private HealthBar healthBar;
    public GameObject GameOverUI;

    public bool gameIsOver = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameOverUI.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        //if (collision.gameObject.CompareTag("Trap")) {
        //    Die();
        // }
        
            //falling off tiles
            if (collision.gameObject.CompareTag("void") && player != null)
            {
                player.TakeDamage(999);
                //Die();
            }
        
    }

    public void Die() {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        gameIsOver = true;
       
       
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver() {
        if (gameIsOver) { GameOverUI.SetActive(true); }
        else { GameOverUI.SetActive(false); }
        
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 50;
    private Animator anim;
    public Slider slider;
    public Image Fill;
    //public Score score = default;
    private int MaxEHealth = 50;
    public bool deadEnemy = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
        SetMax();
    }
    public void SetMax() {
        slider.maxValue = MaxEHealth;
        slider.value = MaxEHealth;

    }

    public void SetEHealth(int amount) {
        slider.value = enemyHealth - amount;

    }

    public void DamageEnemy(int amount) {
        if (amount < 0) {
            throw new System.ArgumentOutOfRangeException("no negative damage!");

        }

        this.enemyHealth -= amount;
        SetEHealth(amount);
        anim.SetTrigger("Hurt");
        if (enemyHealth <= 0) {
            EnemyDie();
        }
    }

    private void EnemyDie() {
        //score.AddScore(50);
        deadEnemy = true;
        Debug.Log("killed enemy");
        anim.SetTrigger("Dead");
        Destroy(gameObject, .5f);
    }

}

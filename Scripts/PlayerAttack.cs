using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject AttackArea = default;
    public StaminaBar stamina;
   
    
   

    public bool attacking = false;

    private float timeToAttack = .25f;
    private float timer = 0f;
    

    private void Start()
    {
        AttackArea = transform.GetChild(0).gameObject;
    }

    private void Update()
    {


      

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }



        if (attacking) {
            timer += Time.deltaTime;

            if (timer >= timeToAttack) {
                timer = 0;
                attacking = false;
                AttackArea.SetActive(attacking);
            }
        }

        
    }

    public void Attack() {

        attacking = true;
        AttackArea.SetActive(attacking);
       
       
        
    }

}

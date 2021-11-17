using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //private Animator anim;
    public bool hasKey = false;
    

    
    private void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("hasKey", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasKey = true;
            gameObject.SetActive(false);
            //anim.SetBool("hasKey", true);
        }
    }
}

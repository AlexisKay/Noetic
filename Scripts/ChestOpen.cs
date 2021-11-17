using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    private Animator anim;
    public GameObject OpenChest;
    public GameObject ClosedChest;
    public bool ChestisOpen = false;

    //public RuntimeAnimatorController swordController;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ClosedChest.SetActive(true);
        OpenChest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //anim.SetBool("IsOpen", true);
        ClosedChest.SetActive(false);
        OpenChest.SetActive(true);
        ChestisOpen = true;
        //anim.SetTrigger("Opened");


    }
}

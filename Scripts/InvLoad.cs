using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvLoad : MonoBehaviour
{
    private Animator anim;
    public Key key;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("hasKey", false);
    }

    private void Update()
    {
        if (key.hasKey == true) {
            anim.SetBool("hasKey", true);
        }
    }
}

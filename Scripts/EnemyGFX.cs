using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyGFX : MonoBehaviour
{
    private Animator anim;
    public AIPath aipath;
    public SpriteRenderer sprite;
    public Player player;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (aipath.desiredVelocity.x >= 0.01f) {
            sprite.flipX=true;
            anim.SetBool("IsRunning", true);
        } else if (aipath.desiredVelocity.x <= -0.01f) {
            sprite.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else
            anim.SetBool("IsRunning", false);
            
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            player.TakeDamage(15);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public static bool IsDead = false;

    private void Start()
    {
        if (gm == null) {
            gm = this; 
        }
    }

    public static void KillPlayer(Player player) {
        IsDead = true;
    }

    //public static void KillEnemy() { }
}

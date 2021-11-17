using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{ 
    public PlayerLife playerLife;


    public void Continue(){
        playerLife.RestartLevel();
    }

    public void QuitGame() {
        Application.Quit();
    }
}

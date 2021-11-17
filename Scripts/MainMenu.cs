using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    //public Animator anim;
    public void PlayGame(){
    
        SceneManager.LoadScene(2);

    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endDoor : MonoBehaviour
{

    public Key key;
    public GameObject EndgameUI;

    private void Update()
    {
        EndgameUI.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            EndGame();
        }
    }
    public void EndGame()
    {
        if (key.hasKey == true) { EndgameUI.SetActive(true); }
        else { 
            EndgameUI.SetActive(false);
            Debug.Log("you need the key");
        
        }

    }
}

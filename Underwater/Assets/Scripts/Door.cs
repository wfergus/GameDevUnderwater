using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Activate"))
            {

                Debug.Log("player has door activated");
            }
        }
    }

    public string sceneToLoad;
    private bool isPlayerInTrigger;
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isPlayerInTrigger)
        {
            Debug.Log("player activated trigger");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trigger : MonoBehaviour {

    [SerializeField]
    DoorBlock doorBlock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Debug.Log("Block hit trigger");
            doorBlock.isThere = false;
        }
        else
        {
            Debug.Log("non-player has entered the hazard");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    public Vector2 Direction = new Vector2();

    protected HazardState state;
    public HazardState State
    {
        get { return state; }
        set
        {
            if (this.state != value)
            {
                this.state = value;

                switch (State)
                {
                    case HazardState.Spawning:
                        break;
                    case HazardState.Flying:
                        break;
                    case HazardState.Dead:
                        break;
                }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered hazard.");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Character player = collision.GetComponent<Character>();
            player.KillPlayer();

        }
        else
        {
            Debug.Log("non-player has entered the hazard");
        }
    }
    public Hazard()
    {
        this.State = HazardState.Flying;
    }

}
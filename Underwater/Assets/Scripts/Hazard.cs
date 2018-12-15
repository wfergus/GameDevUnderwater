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
    public Hazard()
    {
        this.State = HazardState.Flying;
    }

}
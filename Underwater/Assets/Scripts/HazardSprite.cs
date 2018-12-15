using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HazardState { Spawning, Flying, Dead }
public class HazardSprite : MonoBehaviour {


    public HazardState State;

    protected Hazard hazard;
    public float Speed;

    private Vector3 moveTranslation;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        this.hazard = new Hazard();
    }
    void Start()
    {
        this.SetupBullet();
      
    }
    public void SetupBullet()
    {
   

        this.State = this.hazard.State;
    }
    
    void Update()
    {

        switch (this.State)
        {
            case HazardState.Spawning:
                new Hazard();
                break;

            case HazardState.Flying:
                this.hazard.Direction.x = -1;

                break;

            case HazardState.Dead:

                break;
        }

        this.moveTranslation = new Vector3(this.hazard.Direction.x, this.hazard.Direction.y) * Time.deltaTime * this.Speed;
        this.transform.position = new Vector3(this.transform.position.x + this.moveTranslation.x,
                                              this.transform.position.y);

        if (this.State != this.hazard.State)
        {
            this.State = this.hazard.State;
        }
    }
}

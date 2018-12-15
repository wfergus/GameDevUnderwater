using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour {

    public int maxBullets = 20;
    public GameObject hazard;
    public float horizontalSpawn = 14.5f;
    public float verticalMin = -6f;
    public float verticalMax = 6f;
    public Vector2 originPosition;

    void Start()
    {
        originPosition = transform.position;
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(horizontalSpawn, Random.Range(verticalMin, verticalMax));
            Instantiate(hazard, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }
}

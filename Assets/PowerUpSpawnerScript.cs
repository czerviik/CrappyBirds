using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnerScript : MonoBehaviour
{
    public GameObject powerUpHeavy;
    public GameObject powerUpInv;

    public float rarityHeavy = 15;
    public float rarityInv = 25;
    public float heightOffset = 10;

    private readonly float randomSpawnHeavyMin = 5;
    private readonly float randomSpawnInvMin = 15;
    private float actualSpawnRateHeavy;
    private float actualSpawnRateInv;
    private float timerHeavy = 0;
    private float timerInv = 0;


    // Start is called before the first frame update
    private void Start()
    {
        
    }
    // Update is called once per frame

    void Update()
    {
        actualSpawnRateHeavy = Random.Range(randomSpawnHeavyMin, randomSpawnHeavyMin + rarityHeavy);

        timerHeavy += Time.deltaTime;
        if (timerHeavy >= actualSpawnRateHeavy)
        {
            SpawnPowerUpHeavy();
            timerHeavy = 0;
        }

        actualSpawnRateInv = Random.Range(randomSpawnInvMin, randomSpawnInvMin + rarityInv);

        timerInv += Time.deltaTime;
        if (timerInv >= actualSpawnRateInv)
        {
            SpawnPowerUpInv();
            timerInv = 0;
        }

    }

    void SpawnPowerUpHeavy()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(powerUpHeavy, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

    void SpawnPowerUpInv()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(powerUpInv, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Pipe")
        {
            
            if (gameObject == powerUpHeavy)
            {
                SpawnPowerUpHeavy();
                Destroy(gameObject);
            }

            Debug.Log("Power up spawned on a pipe. Destroyed and made a brand new!");

        }

    }
}

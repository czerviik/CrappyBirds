using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnerScript : MonoBehaviour
{
    public GameObject powerUpHeavy;
    public GameObject powerUpInv;
    public LogicScript logic;

    public float rarityHeavy = 15;
    public float rarityInv = 25;
    public float heightOffset = 10;

    private readonly float randomSpawnHeavyMin = 5;
    private readonly float randomSpawnInvMin = 15;
    private float actualSpawnRateHeavy;
    private float actualSpawnRateInv;
    private float timerHeavy = 0;
    private float timerInv = 0;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (!logic.gameStarted) return;
        actualSpawnRateHeavy = Random.Range(randomSpawnHeavyMin, randomSpawnHeavyMin + rarityHeavy);
        HandlePowerUpSpawn(ref timerHeavy, actualSpawnRateHeavy, powerUpHeavy);

        actualSpawnRateInv = Random.Range(randomSpawnInvMin, randomSpawnInvMin + rarityInv);
        HandlePowerUpSpawn(ref timerInv, actualSpawnRateInv, powerUpInv);
    }

    void HandlePowerUpSpawn(ref float timer, float actualSpawnRate, GameObject powerUpType)
    {
        timer += Time.deltaTime;
        if (timer >= actualSpawnRate)
        {
            SpawnPowerUp(powerUpType);
            timer = 0;
        }
    }

    void SpawnPowerUp(GameObject powerUpType)
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(powerUpType, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    public float lowestSpawnRate = 1.2f;
    private float actualSpawnRate;
    private float timer = 0;
    public float heightOffset = 10;
    public LogicScript logic;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        actualSpawnRate = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.gameStarted) return;

        if (actualSpawnRate > lowestSpawnRate)
        {
            actualSpawnRate = spawnRate - logic.GetScore() / 40;
        }
        

        timer += Time.deltaTime;
        if (timer >= actualSpawnRate)
        {
            spawnPipe();
            timer = 0;
        }       

    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x,Random.Range(lowestPoint,highestPoint),0), transform.rotation);
    }
}

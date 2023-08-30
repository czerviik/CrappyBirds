using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class startScript : MonoBehaviour
{
    public TextMeshProUGUI gameHelp;
    public bool gameStarted = false;
    public LogicScript logic;
    public PipeSpawnScript pipeSpawner;

    // Start is called before the first frame update
    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSpawner = GameObject.FindGameObjectWithTag("Pipe Spawn").GetComponent<PipeSpawnScript>();


        gameHelp.text = "<color=#dede16>mezerníkem</color> zamávej křídly!";
        Debug.Log("Setting gameHelp text...");

    }

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            logic.StartGame();
            pipeSpawner.spawnPipe();
            gameStarted = true;


            if (gameHelp != null)
            {
                Destroy(gameHelp.gameObject);
            }
        }

    }
}

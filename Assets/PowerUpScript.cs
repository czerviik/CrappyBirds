using UnityEngine;

public class PowerUp : PipeMoveScript
{
    public PowerUpType powerUpType;
    public PowerUpManagerScript powerUpManagerScript;
    public TimerBarLogicScript timerBarSpawn;
    public GameObject pipeCollision;

    public override void Start()
    {
        powerUpManagerScript = FindObjectOfType<PowerUpManagerScript>();
        timerBarSpawn = GameObject.FindGameObjectWithTag("TimerBarScript").GetComponent<TimerBarLogicScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    public override void Update()
    {
        actualSpeed = moveSpeed + logic.GetScore() / 10;
        transform.position += Vector3.left * actualSpeed * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Debug.Log("PowerUp destroyed");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Bird"))
        {
            // Apply powerUp
            if (powerUpManagerScript != null)
            {
                powerUpManagerScript.ApplyPowerUp(powerUpType);
            }
            timerBarSpawn.TimerBarSpawn(powerUpType);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Pipe Part"))
        {
            Destroy(gameObject);
            powerUpManagerScript.ApplyPowerUp(powerUpType);
        }
    }
}

public enum PowerUpType
{
    Heavy,
    Invicibility
}

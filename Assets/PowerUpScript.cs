using UnityEngine;

public class PowerUp : PipeMoveScript
{
    public PowerUpType powerUpType;

    public PowerUpManagerScript powerUpManagerScript;

    public override void Start()
    {
        powerUpManagerScript = FindObjectOfType<PowerUpManagerScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    public override void Update()
    {
        actualSpeed = moveSpeed + logic.GetScore() / 10;
        //Debug.Log(actualSpeed);
        transform.position += Vector3.left * actualSpeed * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Debug.Log("Bim ho. PowerUp destroyed");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bird"))
        {
            powerUpManagerScript.ApplyPowerUp(powerUpType);
            Destroy(gameObject);
        }
    }
}

public enum PowerUpType
{
    Heavy,
    Invicibility
}

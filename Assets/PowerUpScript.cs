using UnityEngine;

public class PowerUp : PipeMoveScript
{
    public PowerUpType powerUpType;
    public GameObject timerManagerPrefab;
    public PowerUpManagerScript powerUpManagerScript;

    public override void Start()
    {
        powerUpManagerScript = FindObjectOfType<PowerUpManagerScript>();
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

            // Get canvas transform reference
            Transform canvasTransform = GameObject.FindGameObjectWithTag("Canvas").transform;

            // Instantiate the prefab and set its parent to the canvas
            GameObject newPowerUpBar = Instantiate(timerManagerPrefab);
            newPowerUpBar.transform.SetParent(canvasTransform, false);
            newPowerUpBar.transform.localPosition = Vector3.zero;
            newPowerUpBar.transform.localScale = Vector3.one;

            Destroy(gameObject);
        }
    }
}

public enum PowerUpType
{
    Heavy,
    Invicibility
}

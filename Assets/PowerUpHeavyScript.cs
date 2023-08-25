using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeavyScript : PipeMoveScript
{
    public PowerUpManagerScript powerUpManager;
    // Update is called once per frame

    public override void Start()
    {
        powerUpManager = GameObject.FindGameObjectWithTag("powerUpManager").GetComponent<PowerUpManagerScript>();
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
        if (collision.name == "Bird")
        {
            powerUpManager.ApplyPowerUpHeavy();
            Destroy(gameObject);
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManagerScript : MonoBehaviour
{
    public BirdScript3 birdScript;
    public GameObject Bird;
    public float powerUpHeavyTime = 5;
    public float powerUpHeavyStrength = 5;
    public float powerUpInvicTime = 5;

    void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript3>();
    }

    public void ApplyPowerUp(PowerUpType powerUpType)
    {
        switch(powerUpType)
        {
            case PowerUpType.Heavy:
                StartCoroutine(AdjustFlapStrength(-powerUpHeavyStrength, powerUpHeavyTime));
                break;
            case PowerUpType.Invicibility:
                StartCoroutine(SetInvincibility(Bird, powerUpInvicTime));
                break;
        }
    }

    IEnumerator AdjustFlapStrength(float amount, float duration)
    {
        birdScript.flapStrength += amount;
        yield return new WaitForSeconds(duration);
        birdScript.flapStrength -= amount;
    }

    IEnumerator SetInvincibility(GameObject bird, float duration)
    {
        bird.GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        bird.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}

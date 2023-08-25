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

    public void ApplyPowerUpHeavy()
    {
        StartCoroutine(PowerUpH(powerUpHeavyTime,powerUpHeavyStrength));
    }

    IEnumerator PowerUpH(float waitTime,float powerUpHeavyStrength)
    {
        birdScript.flapStrength -= powerUpHeavyStrength;
        yield return new WaitForSeconds(waitTime);
        birdScript.flapStrength += powerUpHeavyStrength;
    }

    public void ApplyPowerUpInvicibility()
    {
        StartCoroutine(PowerUpI(Bird, powerUpInvicTime));
    }

    IEnumerator PowerUpI(GameObject bird, float waitTime)
    {
        bird.GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        bird.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}

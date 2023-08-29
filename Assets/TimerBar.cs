using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Image timerBar;
    public GameObject powerUpTextHeavy;
    public GameObject powerUpTextInv;
    private float maxTime;
    public PowerUpManagerScript powerUpManagerScript;
    private float timeRemaining;
    public PowerUpType powerUpType;
    private bool timerIsActive = false;

    void Start()
    {
        powerUpManagerScript = FindObjectOfType<PowerUpManagerScript>();
        StartTimeBar(powerUpType);
    }

    void Update()
    {
        if (timerIsActive && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerBar.fillAmount = timeRemaining / maxTime;
        }
        else if (timerIsActive)
        {
            DeactivateTimer();
        }
    }

    public void StartTimeBar(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.Heavy:
                powerUpTextHeavy.SetActive(true);
                maxTime = powerUpManagerScript.powerUpHeavyTime;
                Debug.Log("TimerBar Heavy Started!");
                break;
            case PowerUpType.Invicibility:
                powerUpTextInv.SetActive(true);
                maxTime = powerUpManagerScript.powerUpInvicTime;
                Debug.Log("TimerBar Invicibility Started!");
                break;
        }
        timerIsActive = true;
        Debug.Log("timerIsActive is set to true");
        timeRemaining = maxTime;
    }

    private void DeactivateTimer()
    {
        timerIsActive = false;
        Destroy(gameObject);  // Destroy the TimerBar instance
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBarLogicScript : MonoBehaviour
{
    public GameObject timerManagerPrefabHeavy;
    public GameObject timerManagerPrefabInv;
    public GameObject[] timerBarsPresent;
    public float nextBarOffset = 2;


    public void TimerBarSpawn(PowerUpType powerUpType)
    {
        timerBarsPresent = GameObject.FindGameObjectsWithTag("TimerBar");

        switch (powerUpType)
        {
            case PowerUpType.Heavy:
                // Get canvas transform reference
                Transform canvasTransform = GameObject.FindGameObjectWithTag("Canvas").transform;

                // Instantiate the prefab and set its parent to the canvas
                GameObject newPowerUpBarHeavy = Instantiate(timerManagerPrefabHeavy);
                newPowerUpBarHeavy.transform.SetParent(canvasTransform, false);

                if (timerBarsPresent.Length < 1)
                {
                    newPowerUpBarHeavy.transform.localPosition = Vector3.zero;

                }
                else
                {
                    newPowerUpBarHeavy.transform.localPosition = new Vector3(0, - nextBarOffset, 0);
                }
                newPowerUpBarHeavy.transform.localScale = Vector3.one;
                break;

            case PowerUpType.Invicibility:

                canvasTransform = GameObject.FindGameObjectWithTag("Canvas").transform;


                GameObject newPowerUpBarInv = Instantiate(timerManagerPrefabInv);
                newPowerUpBarInv.transform.SetParent(canvasTransform, false);

                if (timerBarsPresent.Length < 1)
                {
                    newPowerUpBarInv.transform.localPosition = Vector3.zero;
                }
                else
                {
                    newPowerUpBarInv.transform.localPosition = new Vector3(0,- nextBarOffset, 0);
                }
                newPowerUpBarInv.transform.localScale = Vector3.one;
                break;
        }
  
    }
}

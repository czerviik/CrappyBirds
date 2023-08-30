using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBarLogicScript : MonoBehaviour
{
    public GameObject timerManagerPrefabHeavy;
    public GameObject timerManagerPrefabInv;
    public GameObject[] timerBarsPresent;
    public float nextBarOffset = 2;
    private bool barOnLvl2 = false;

    public void TimerBarSpawn(PowerUpType powerUpType)
    {
        timerBarsPresent = GameObject.FindGameObjectsWithTag("TimerBar");

        // Determine which prefab to instantiate.
        GameObject prefabToSpawn = (powerUpType == PowerUpType.Heavy) ? timerManagerPrefabHeavy : timerManagerPrefabInv;

        GameObject newPowerUpBar = Instantiate(prefabToSpawn);

        //add to canvas "layer"
        Transform canvasTransform = GameObject.FindGameObjectWithTag("Canvas").transform;
        newPowerUpBar.transform.SetParent(canvasTransform, false);

        //handling multiple timerbars
        if (timerBarsPresent.Length == 0)
        {
            newPowerUpBar.transform.localPosition = Vector3.zero;
            barOnLvl2 = false;
        }
        else if (timerBarsPresent.Length == 1)
        {
            if (!barOnLvl2)
            {
                newPowerUpBar.transform.localPosition = new Vector3(0, -nextBarOffset, 0);
                barOnLvl2 = true;
            }
            else
            {
                newPowerUpBar.transform.localPosition = Vector3.zero;
                barOnLvl2 = false;
            }

        }
        else if (timerBarsPresent.Length == 2)
        {
            newPowerUpBar.transform.localPosition = new Vector3(0, nextBarOffset, 0);
        }

        newPowerUpBar.transform.localScale = Vector3.one;

    }
}

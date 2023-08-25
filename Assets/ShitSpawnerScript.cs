using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitSpawnerScript : MonoBehaviour
{
    public GameObject shitPrefab;

    public void SpawnShit(GameObject bird)
    {
        //spawn na místo souřadnic objektu bird
        GameObject newShit = Instantiate(shitPrefab, bird.transform.position + new Vector3(0, -1, 0), Quaternion.identity);

        // lock souřadnic objektu bird
        newShit.transform.SetParent(bird.transform);
    }
}

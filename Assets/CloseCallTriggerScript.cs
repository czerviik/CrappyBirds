using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCallTriggerScript : MonoBehaviour
{
    public ShitSpawnerScript shit;

    // Start is called before the first frame update
    void Start()
    {
        shit = GameObject.FindGameObjectWithTag("shitSpawn").GetComponent<ShitSpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

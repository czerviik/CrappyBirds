using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBirdMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float Speed;
    public float AmplitudeOffset;
    public float Amplitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.Sin(Time.time * Speed)*Amplitude + AmplitudeOffset);
    }
}

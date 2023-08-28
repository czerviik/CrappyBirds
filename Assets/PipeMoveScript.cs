using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 10;
    public float deadZone = -25;
    protected float actualSpeed;
    public LogicScript logic;
    // Start is called before the first frame update
    public virtual void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        actualSpeed = moveSpeed + logic.GetScore() / 10;
        //Debug.Log(actualSpeed);
        transform.position += Vector3.left * actualSpeed * Time.deltaTime;
        if(transform.position.x < deadZone)
        {
            Debug.Log("Bam. Pipe destroyed");
            Destroy(gameObject);
        }
    }
}

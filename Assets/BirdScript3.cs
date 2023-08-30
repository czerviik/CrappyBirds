using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;

public class BirdScript3 : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float maxHeight;
    public float minHeight;
    public float angleModifier = 2f;
    public float maximumAngle = 30f;
    public float shitHangTime = 1f;
    public bool hasSpawnedShit;
    public float timeBeforeShitSpawn = 0.5f;

    public Animator animator;
    private ShakeScript shake;
    public GameObject featherBurst;
    public GameObject shitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        shake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<ShakeScript>();
        logic.showHighScore();
        GetComponent<Rigidbody2D>().isKinematic = true;
        animator.SetBool("swing", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.gameStarted) return;

        GetComponent<Rigidbody2D>().isKinematic = false;
        animator.SetBool("swing", false);

        //wing swing
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            animator.SetBool("swing",true);
            myRigidbody2D.velocity = Vector2.up * flapStrength;

        }
        //make a shit
        if (Input.GetKeyDown(KeyCode.S) && birdIsAlive)
        {
            StartCoroutine(SpawnShit());
            hasSpawnedShit = true;
            Debug.Log("Shit triggered");
        }

        //automatic rotation of the bird
        float angle = Mathf.Atan2(myRigidbody2D.velocity.y,angleModifier) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -maximumAngle, maximumAngle);

        transform.rotation = Quaternion.Euler(0, 0, angle);

        OutOfScreenCheck();
    }

    // shit trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.name == "CloseCallTriggerTop" || other.name == "CloseCallTriggerBot") && !hasSpawnedShit)
        {
            StartCoroutine(SpawnShit());
            hasSpawnedShit = true;
            Debug.Log("Shit triggered");
        }

    }
    // bird collides with a pipe
    private void OnCollisionEnter2D(Collision2D collision)
    {

        featherBurst.SetActive(true);
        FeatherBurst();
        featherBurst.SetActive(false);
        myRigidbody2D.velocity = Vector2.left * 5;
        shake.CamShake();
        logic.GameOver();
        birdIsAlive = false;
        animator.SetTrigger("death");
    }

    //bird leaves the screen
    private void OutOfScreenCheck()
    {
        if (transform.position.y > maxHeight || transform.position.y < minHeight)
        {
            logic.GameOver();
            birdIsAlive = false;
        }
        
    }

    private void FeatherBurst()
    {
        Instantiate(featherBurst, transform.position, Quaternion.identity);
    }

    //droping a shit mechanic
    private IEnumerator SpawnShit()
    {
        // Wait for a specific amount of time (e.g., 0.5 seconds)
        yield return new WaitForSeconds(timeBeforeShitSpawn);

        // Check if the bird is alive
        if (birdIsAlive)
        {
            //intance shit objektu
            GameObject newShit = Instantiate(shitPrefab, transform.position + new Vector3(-0.7f, -0.8f, 0), Quaternion.Euler(0, 0, 0));

            // postarat se o shit, follow souřadnic birda a detach
            StartCoroutine(FollowBirdPosition(newShit));
        }
            
    }

    private IEnumerator FollowBirdPosition(GameObject shit)
    {
        float elapsedTime = 0;
        while (elapsedTime < shitHangTime)
        {
            if (shit == null)
            {
                yield break; // Exit the coroutine
            }
            // Update the position to follow the bird
            shit.transform.position = transform.position + new Vector3(-0.7f, -0.8f, 0);

            // Set the rotation to always point downwards
            shit.transform.rotation = Quaternion.Euler(0, 0, 0);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Detach the shit
        shit.GetComponent<Rigidbody2D>().isKinematic = false;
        hasSpawnedShit = false;
    }

}

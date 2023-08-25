using UnityEngine;

public class ShitScript : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
            Debug.Log("shit destroyed");
        }
    }
}
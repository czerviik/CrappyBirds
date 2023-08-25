using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    public Animator canAnim;

    public void CamShake()
    {
        canAnim.SetTrigger("shake");
    }
}

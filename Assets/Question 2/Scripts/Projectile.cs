using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Hit detection
    private void OnCollisionEnter(Collision collision)
    {
        Targets t = collision.gameObject.GetComponent<Targets>();
        if (t)
            t.TargetHit();
    }
}

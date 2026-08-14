using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    float _speed = 2000f;
    float _lifetimeSeconds = 10f;
    float _lifetimeTimer = 0f;

    void Update()
    {
        _lifetimeTimer += Time.deltaTime;
        rb.linearVelocity = transform.forward * _speed * Time.deltaTime;

        if (_lifetimeTimer > _lifetimeSeconds)
        {
            Destroy(gameObject);
        }
    }

    //Hit detection
    private void OnCollisionEnter(Collision collision)
    {
        Targets t = collision.gameObject.GetComponent<Targets>();
        if (t)
        {
            t.TargetHit();
        }

        Destroy(gameObject);
    }
}

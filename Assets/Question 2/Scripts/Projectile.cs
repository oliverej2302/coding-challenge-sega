using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    float _speed = 20f; //8000f;
    float _lifetimeSeconds = 10f;
    float _lifetimeTimer = 0f;

    void Start()
    {
        rb.linearVelocity = transform.forward * _speed;
    }

    void Update()
    {
        _lifetimeTimer += Time.deltaTime;

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

        //Debug.Log("YOU HIT " + collision.gameObject);

        Destroy(gameObject);
    }
}

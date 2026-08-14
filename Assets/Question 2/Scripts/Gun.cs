using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform WeaponMuzzle;
    public float DelayBetweenShots = 1f;
    [SerializeField]
    GameObject _projectile;
    float _pojectileSpeed = 20f;
    float _shotTimer = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveProjectiles();
        _shotTimer += Time.deltaTime;
    }

    //Get input to fire gun
    public void FireGun(InputAction.CallbackContext context)
    {
        if (_shotTimer >= DelayBetweenShots)
        {
            _shotTimer = 0;
            GameObject spawnProjectile = Instantiate(_projectile, WeaponMuzzle.position, WeaponMuzzle.rotation);
            spawnProjectile.transform.position += spawnProjectile.transform.forward * _pojectileSpeed * Time.deltaTime;
        }
    }

    //move the all active projectiles
    void MoveProjectiles()
    {
        var projectiles = FindObjectsByType<Projectile>(FindObjectsSortMode.None);
        foreach (Projectile go in projectiles)
        {
            go.transform.position += (go.transform.forward * _pojectileSpeed) * Time.deltaTime;
        }
    }
}

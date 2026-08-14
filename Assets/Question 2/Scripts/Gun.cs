using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform WeaponMuzzle;
    public float DelayBetweenShotsSeconds = 1f;
    [SerializeField]
    GameObject _projectilePrefab;
    float _shotTimer = 0;

    void Update()
    {
        _shotTimer += Time.deltaTime;
    }

    //Get input to fire gun
    public void FireGun(InputAction.CallbackContext context)
    {
        if (_shotTimer >= DelayBetweenShotsSeconds)
        {
            _shotTimer = 0;
            Instantiate(_projectilePrefab, WeaponMuzzle.position, WeaponMuzzle.rotation);
        }
    }
}

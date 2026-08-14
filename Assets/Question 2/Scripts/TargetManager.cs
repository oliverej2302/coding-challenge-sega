using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    GameObject _targetToSpawn;
    [SerializeField]
    Vector3 _maxPosition, _minPosition = Vector3.zero;
    [SerializeField]
    float _minWaitToSpawn, _maxWaitToSpawn = 0;
    float _spawnTimer = 0;
    float _spawnDelay = 0;

    bool _isMovingTarget = true;

    //stress test controls
    private bool _isStressTestEnabled = true;
    private int stressTestTargetCount = 750;

    // Start is called before the first frame update
    void Start()
    {
        if (_isStressTestEnabled)
        {
            for (int i = 0; i < stressTestTargetCount; i++)
            {
                SpawnTarget();
            }
        }
        else
        {
            SpawnTarget();
            _spawnDelay = Random.Range(_minWaitToSpawn, _maxWaitToSpawn);
        }

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (_isStressTestEnabled) return;
        if (_spawnTimer >= _spawnDelay)
        {
            _spawnTimer = 0;
            _spawnDelay = Random.Range(_minWaitToSpawn, _maxWaitToSpawn);
            SpawnTarget();
        }
        _spawnTimer += Time.deltaTime;
    }

    //spawn target in random location
    void SpawnTarget()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(_minPosition.x, _maxPosition.x), Random.Range(_minPosition.y, _maxPosition.y), Random.Range(_minPosition.z, _maxPosition.z));
        GameObject targetSpawned = Instantiate(_targetToSpawn, spawnLocation, Quaternion.identity, transform);
        Targets t = targetSpawned.GetComponent<Targets>();
        t.Init(_isMovingTarget, _minPosition, _maxPosition);
    }
}

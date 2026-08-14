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

    //stress test controls
    private bool _isStressTestEnabled = false;
    private int stressTestTargetCount = 500;

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
        Vector3 spawnLoactaion = new Vector3(Random.Range(_maxPosition.x, _minPosition.x), Random.Range(_maxPosition.y, _minPosition.y), Random.Range(_maxPosition.z, _minPosition.z));
        GameObject targetSpawned = (GameObject)Instantiate(_targetToSpawn, spawnLoactaion, Quaternion.identity);
        Targets t = targetSpawned.GetComponent<Targets>();
        t.Init(true, _minPosition, _maxPosition);
        targetSpawned.transform.parent = this.transform;
    }
}

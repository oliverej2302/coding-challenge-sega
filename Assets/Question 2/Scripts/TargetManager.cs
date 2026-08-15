using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    GameObject _targetToSpawn;
    [SerializeField]
    Vector3 _maxPosition, _minPosition = Vector3.zero;
    [SerializeField]
    float _minWaitToSpawn, _maxWaitToSpawn = 0;
    TargetManager spawnedTargetsManager;
    float _spawnTimer = 0;
    float _spawnDelay = 0;
    int _maxTargetCount = 20;
    int _currentTargetCount = 0;

    bool _isMovingTarget = true;

    //stress test controls
    private bool _isStressTestEnabled = false;
    private int stressTestTargetCount = 750;

    // Start is called before the first frame update
    void Start()
    {
        spawnedTargetsManager = this;
        if (_isStressTestEnabled)
        {
            _maxTargetCount = stressTestTargetCount;
            for (int i = 0; i < _maxTargetCount; i++)
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
            if (_currentTargetCount < _maxTargetCount)
            {
                SpawnTarget();
            }
            _spawnTimer = 0;
            _spawnDelay = Random.Range(_minWaitToSpawn, _maxWaitToSpawn);
        }
        _spawnTimer += Time.deltaTime;
    }

    public void ChangeTargetCount(int value)
    {
        _currentTargetCount += value;
        Debug.Log("Current count = " + _currentTargetCount);
    }

    //spawn target in random location
    void SpawnTarget()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(_minPosition.x, _maxPosition.x), Random.Range(_minPosition.y, _maxPosition.y), Random.Range(_minPosition.z, _maxPosition.z));
        GameObject targetSpawned = Instantiate(_targetToSpawn, spawnLocation, Quaternion.identity, transform);
        Targets t = targetSpawned.GetComponent<Targets>();
        t.Init(spawnedTargetsManager, _isMovingTarget, _minPosition, _maxPosition);
    }
}

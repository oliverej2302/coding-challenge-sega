using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField]
    float _minMoveSpeed, _maxMoveSpeed = 1f;
    [SerializeField]
    Vector3 _maxPosition, _minPosition = Vector3.zero;
    float _currentSpeed = 0;
    Vector3 _targetMovePosition;
    bool IsMoving = false;
    float _sqrLerpPositionReachedThreshold = 0.2f * 0.2f;

    //initialize target
    public void Init(bool m, Vector3 min, Vector3 max)
    {
        IsMoving = m;
        _minPosition = min;
        _maxPosition = max;
        if (IsMoving)
        {
            SetNextTarget();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTarget();
    }

    //Move Target
    void MoveTarget()
    {
        //Debug.Log("Is moving: " + IsMoving + " to position " + _targetMovePosition);
        if (IsMoving)
        {
            float sqrDist = (transform.position - _targetMovePosition).sqrMagnitude;
            if (sqrDist <= _sqrLerpPositionReachedThreshold)
            {
                SetNextTarget();
            }
            Vector3 movePosition = Vector3.Lerp(transform.position, _targetMovePosition, Time.deltaTime * _currentSpeed);
            transform.position = movePosition;
        }
    }

    private void SetNextTarget()
    {
        _currentSpeed = Random.Range(_minMoveSpeed, _maxMoveSpeed);
        _targetMovePosition = new Vector3(Random.Range(_minPosition.x, _maxPosition.x), Random.Range(_minPosition.y, _maxPosition.y), Random.Range(_minPosition.z, _maxPosition.z));
    }

    //Target hit by projectile
    public void TargetHit()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField]
    float _minMoveSpeed,_maxMoveSpeed = 1f;
    [SerializeField]
    Vector3 _maxPosition, _minPosition =Vector3.zero;
    float _currentSpeed = 0;
    Vector3 _targetMovePosition;
    MeshRenderer _tartgetRender;
    BoxCollider _targetColider;
    bool IsMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        _tartgetRender = GetComponent<MeshRenderer>();
        _targetColider = GetComponent<BoxCollider>();
    }

    //initialize target
    public void Init(bool m,Vector3 min, Vector3 max)
    {
        IsMoving = m;
        _minPosition = max;
        _maxPosition = min;
        if (IsMoving)
        {
            _currentSpeed = Random.Range(_minMoveSpeed, _maxMoveSpeed);
            _targetMovePosition = new Vector3(Random.Range(_maxPosition.x, _minPosition.x), Random.Range(_maxPosition.y, _minPosition.y), Random.Range(_maxPosition.z, _minPosition.z));
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
        Debug.Log("Is moving: " + IsMoving + " to position " + _targetMovePosition);
        if (IsMoving)
        {
            float dist = Vector3.Distance(transform.position, _targetMovePosition);
            if (dist <= 0.2f)
            {
                _currentSpeed = Random.Range(_minMoveSpeed, _maxMoveSpeed);
                _targetMovePosition = new Vector3(Random.Range(_maxPosition.x, _minPosition.x), Random.Range(_maxPosition.y, _minPosition.y), Random.Range(_maxPosition.z, _minPosition.z));
            }
            Vector3 movePosition = Vector3.Lerp(transform.position, _targetMovePosition, Time.deltaTime * _currentSpeed);
            transform.position = movePosition;
        }
    }

    //Target hit by projectile
    public void TargetHit()
    {
        _tartgetRender.enabled = false;
        _targetColider.enabled = false;
    }
}

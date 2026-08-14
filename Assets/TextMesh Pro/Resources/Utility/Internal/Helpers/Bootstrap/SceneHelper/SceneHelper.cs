using UnityEngine;

public class ShowObject : MonoBehaviour
{
    [SerializeField]
    GameObject _gameObject;
    [SerializeField]
    Transform _transformParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instantiate(_gameObject,new Vector3(0.2639997f, 0.7861894f, -10.48515f),Quaternion.identity,_transformParent);
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    private float _posZ;

    private void Awake()
    {
        _posZ = transform.position.z;
    }

    void Update()
    {
        Vector3 position = _target.position;
        position.z = _posZ;
        transform.position = position;
    }
}

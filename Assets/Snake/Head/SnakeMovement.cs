using System;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private float _rotationSpeed;
    private float _moveSpeed;
    private Vector3 _direction;
    private bool _initialized;

    public void Init(SnakeConfig config)
    {
        if (config is null)
            throw new ArgumentNullException(nameof(config));
        if (_initialized)
            throw new InvalidOperationException(name + " is already initialized");

        _rotationSpeed = config.RotationSpeed;
        _moveSpeed = config.MoveSpeed;
    }

    public void SetDirection(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        _direction = Vector3.Lerp(transform.up, direction, Time.deltaTime * _rotationSpeed);
        transform.up = Vector3.ProjectOnPlane(_direction, Vector3.forward);
    }

    private void Update()
    {
        transform.position += transform.up * _moveSpeed * Time.deltaTime;
    }
}

using System;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    [SerializeField]
    private SnakeMovement _head;
    [SerializeField]
    private Camera _gameCamera;

    private void Awake()
    {
        if (_head is null)
            throw new ArgumentNullException(nameof(_head));
        if (_gameCamera is null)
            throw new ArgumentNullException(nameof(_gameCamera));
    }

    private void Update()
    {
        Vector2 mousePos = _gameCamera.ScreenToWorldPoint(Input.mousePosition);
        _head.SetDirection(mousePos);
    }
}

using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SnakeHead : MonoBehaviour, ISnakeKill, IFruitEater
{
    [SerializeField]
    private SnakeConfig _config;
    [SerializeField]
    private SnakeTail _tail;
    [SerializeField]
    private SnakeMovement _movement;

    [SerializeField]
    private GameScore _gameScore;
    [SerializeField]
    private GameFinisher _gameFinisher;

    public event Action<int> OnFruitPicked;
    public event Action OnSnakeKilled;
    public event Action OnSnakeReloaded;

    private Vector3 _startPosition;
    private Collider2D _collision;

    private void Awake()
    {
        if (_config is null)
            throw new ArgumentNullException(nameof(_config));
        if (_movement is null)
            throw new ArgumentNullException(nameof(_movement));
        if (_tail is null)
            throw new ArgumentNullException(nameof(_tail));
        if (_gameScore is null)
            throw new ArgumentNullException(nameof(_gameScore));
        if (_gameFinisher is null)
            throw new ArgumentNullException(nameof(_gameFinisher));

        _collision = GetComponent<Collider2D>();

        Init();
    }

    private void Init()
    {
        _tail.Init(_config);
        _movement.Init(_config);
        _startPosition = transform.position;

        OnFruitPicked += _tail.CreateSegments;
        OnFruitPicked += _gameScore.Add;

        OnSnakeKilled += _tail.Dissolve;
        OnSnakeKilled += _gameFinisher.FinishGame;
        OnSnakeKilled += DisableMovement;
        OnSnakeKilled += DisableCollision;

        OnSnakeReloaded += EnableMovement;
        OnSnakeReloaded += EnableCollision;
        OnSnakeReloaded += _tail.Reload;
        OnSnakeReloaded += MoveToStart;    
    }

    private void DisableMovement() => _movement.enabled = false;
    private void EnableMovement() => _movement.enabled = true;
    private void EnableCollision() => _collision.enabled = true;
    private void DisableCollision() => _collision.enabled = false;
    private void MoveToStart() => transform.position = _startPosition;
    public void Kill() => OnSnakeKilled?.Invoke();
    public void Reload() => OnSnakeReloaded?.Invoke();
    public void EatFruit(int value) => OnFruitPicked?.Invoke(value);
}

using System;
using System.Collections;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField]
    private AppleConfig _config;
    [SerializeField]
    private AppleAnimation _animation;

    private float _cooldown = 5f;
    private int _value = 1;
    private bool _pickable;

    private void Awake()
    {
        if (_config is null)
            throw new ArgumentNullException(nameof(_config));

        _value = _config.Value;
        _cooldown = _config.Cooldown;
    }

    public void Reload()
    {
        StopAllCoroutines();
        SetPickable(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IFruitEater>(out var snake))
        {
            if (_pickable)
            {
                snake.EatFruit(_value);
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Respawn()
    {
        SetPickable(false);

        for (float i = 0; i < _cooldown; i += Time.deltaTime)
            yield return null;

        SetPickable(true);
    }

    private void SetPickable(bool on)
    {
        if (on)
            _animation?.ShowOriginal();
        else
            _animation?.ShowStub();

        _pickable = on;
    }
}

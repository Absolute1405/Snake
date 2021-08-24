using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AppleAnimation : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private ParticleSystem _eatEffect;
    [SerializeField]
    private ParticleSystem _respawnEffect;

    [Header("Animation settings")]
    [SerializeField]
    private Sprite _original;
    [SerializeField]
    private Sprite _stub;
    [SerializeField, Min(1f)]
    private float _maxScale = 1.5f;
    [SerializeField]
    private AnimationCurve _curve;
    [SerializeField, Min(0.1f)]
    private float _duration = 0.5f;

    private Sequence _sequence;
    private float _basicScale;

    private void Awake()
    {
        if (_renderer is null)
            _renderer = GetComponent<SpriteRenderer>();
        if (_eatEffect is null)
            throw new ArgumentNullException(nameof(_eatEffect));
        if (_respawnEffect is null)
            throw new ArgumentNullException(nameof(_respawnEffect));

        if (_original is null)
            throw new ArgumentNullException(nameof(_original));
        if (_stub is null)
            throw new ArgumentNullException(nameof(_stub));

        _basicScale = transform.localScale.x;
        _eatEffect.Stop();
        _respawnEffect.Stop();
    }

    public void ShowOriginal()
    {
        _respawnEffect.Play();
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOScale(_basicScale * _maxScale, _duration).SetEase(_curve));
        _sequence.AppendCallback(() => _renderer.sprite = _original);
    }

    public void ShowStub()
    {
        _eatEffect.Play();
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOScale(_basicScale * _maxScale, _duration).SetEase(_curve));
        _sequence.AppendCallback(() => _renderer.sprite = _stub);
    }
}

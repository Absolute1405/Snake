using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private float _fadeDuration = 1f;
    [SerializeField]
    private float _pauseDuration = 0.3f;

    public UnityEvent OnCountdownEnded;
    private Sequence _sequence;

    private readonly Color _transparent = new Color(0, 0, 0, 0);

    private void Awake()
    {
        if (_image is null)
            throw new ArgumentNullException(nameof(_image));
        if (_text is null)
            throw new ArgumentNullException(nameof(_text));

        _image.color = _transparent;
    }
    private void OnEnable()
    {
        CountFaded();
    }

    private void CountFaded()
    {
        _sequence = DOTween.Sequence();

        SubSequenceAppend("3");
        SubSequenceAppend("2");
        SubSequenceAppend("1");

        _sequence.onComplete = () => OnCountdownEnded.Invoke();
    }

    private void SubSequenceAppend(string number)
    {
        _sequence.AppendCallback(() => _text.text = number);
        _sequence.Append(_image.DOFade(1f, _fadeDuration));
        _sequence.AppendInterval(_pauseDuration);
        _sequence.AppendCallback(() => _image.color = _transparent);
    }
}

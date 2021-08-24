using System;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField]
    private ScoreBox _scoreBox;

    private int _score;

    private void Awake()
    {
        if (_scoreBox is null)
            throw new ArgumentNullException(nameof(_scoreBox));
    }

    public void Add(int score)
    {
        if (score < 0)
            throw new ArgumentOutOfRangeException(nameof(score));

        _score += score;
        _scoreBox?.ShowScore(_score);
    }

    public void Reload()
    {
        _score = 0;
        _scoreBox?.ShowScore(_score);
    }
}

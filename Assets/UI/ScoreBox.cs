using System;
using TMPro;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textField;
    [SerializeField]
    private string _label;

    private void Awake()
    {
        if (_textField is null)
            throw new ArgumentOutOfRangeException(nameof(_textField));
    }

    public void ShowScore(int score)
    {
        _textField.text = _label + score.ToString();
    }
}

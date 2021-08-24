using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    private SegmentMovement _segmentPrefab;
    private float _distanceBetweenSegments;

    private List<SegmentMovement> _segments = new List<SegmentMovement>();
    private List<Vector2> _segmentPositions = new List<Vector2>();
    private bool _initialized;

    public void Init(SnakeConfig config)
    {
        if (config is null)
            throw new ArgumentNullException(nameof(config));
        if (_initialized)
            throw new InvalidOperationException(name + " is already initialized");

        _segmentPrefab = config.SegmentPrefab;
        _distanceBetweenSegments = config.DistanceBetweenSegments;

        _initialized = true;
    }

    private void Update()
    {
        float distance = ((Vector2)transform.position - _segmentPositions[0]).magnitude;

        if (distance > _distanceBetweenSegments)
        {
            Vector2 direction = ((Vector2)transform.position - _segmentPositions[0]).normalized;

            _segmentPositions.Insert(0, _segmentPositions[0] + direction * _distanceBetweenSegments);
            _segmentPositions.RemoveAt(_segmentPositions.Count - 1);

            distance -= _distanceBetweenSegments;
        }

        for (int i = 0; i < _segments.Count; i++)
        {
            _segments[i].Move(_segmentPositions[i + 1], _segmentPositions[i], distance / _distanceBetweenSegments);
        }
    }

    public void CreateSegments(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SegmentMovement _segment = Instantiate(_segmentPrefab, _segmentPositions[_segmentPositions.Count - 1], Quaternion.identity, transform);
            _segments.Add(_segment);
            _segmentPositions.Add(_segment.transform.position);
        }
    }

    public void Dissolve()
    {
        _segments?.ForEach(x => x.MoveRandom());
        enabled = false;
    }

    public void Reload()
    {
        DOTween.KillAll();
        _segments?.ForEach(x => Destroy(x.gameObject));
        enabled = true;

        _segments = new List<SegmentMovement>();
        _segmentPositions = new List<Vector2>();
        _segmentPositions.Add(transform.position);
    }
}

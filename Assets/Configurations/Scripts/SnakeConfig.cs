using UnityEngine;

[CreateAssetMenu(fileName = "New Snake Config", menuName = "Configurations/Snake Config", order = 0)]
public class SnakeConfig : ScriptableObject
{
    [SerializeField, Min(0.1f)]
    private float _rotationSpeed = 3f;
    [SerializeField, Min(0.1f)]
    private float _moveSpeed = 3f;
    [SerializeField, Min(0.01f)]
    private float _distanceBetweenSegments = 0.45f;
    [SerializeField]
    private SegmentMovement _segmentPrefab;

    public float RotationSpeed => _rotationSpeed;
    public float MoveSpeed => _moveSpeed;
    public float DistanceBetweenSegments => _distanceBetweenSegments;
    public SegmentMovement SegmentPrefab => _segmentPrefab;
}

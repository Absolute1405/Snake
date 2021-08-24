using DG.Tweening;
using UnityEngine;

public class SegmentMovement : MonoBehaviour
{
    [SerializeField]
    private float _disconnectedMoveTime = 5f;
    [SerializeField]
    private float _disconnectdMoveRadius = 10f;

    private Sequence _sequence;

    public void Move(Vector2 current, Vector2 next, float distance)
    {
        transform.position = Vector2.Lerp(current, next, distance);
    }

    public void MoveRandom()
    {
        float x = Random.Range(-_disconnectdMoveRadius, _disconnectdMoveRadius);
        float y = Random.Range(-_disconnectdMoveRadius, _disconnectdMoveRadius);

        Vector3 target = new Vector3(x, y) + transform.position;

        _sequence = DOTween.Sequence();
        _sequence.Append(transform?.DOMove(target, _disconnectedMoveTime, false));
        _sequence.AppendCallback(() => gameObject?.SetActive(false));
    }
}

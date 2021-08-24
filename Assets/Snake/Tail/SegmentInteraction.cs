using UnityEngine;

public class SegmentInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ISnakeKill>(out var snake))
        {
            snake.Kill();
        }
    }
}

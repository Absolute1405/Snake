using UnityEngine;
using UnityEngine.Events;

public class GameFinisher : MonoBehaviour
{
    public UnityEvent OnGameOver; 
    public void FinishGame() => OnGameOver?.Invoke();
}

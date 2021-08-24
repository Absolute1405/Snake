using UnityEngine;
using UnityEngine.Events;

public class GameStarter : MonoBehaviour
{
    public UnityEvent OnGameStart;
    private void Start()
    {
        StartGame();
    }

    public void StartGame() => OnGameStart?.Invoke();
}

using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action OnGameOver;

    private void Start()
    {
        OnGameOver += OnGameOverOccurred;
    }

    void OnGameOverOccurred()
    {
        print("Game over");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public Action<TrashType> OnScore;
    public Action<TrashType, TrashType> OnIncorrect;

    public GameManager gameManager;
    public float maxStrikes = 3;


    int currentScore;
    int strikes;
    private void Start()
    {
        OnScore += OnScoreOccurs;
        OnIncorrect += OnIncorrectOccurs;
    }

    void OnScoreOccurs(TrashType trashType)
    {
        //Debug.Log(trashType.ToString());
        currentScore += 1;
        print("Current score: " + currentScore);
    }
    
    void OnIncorrectOccurs(TrashType canTrashType, TrashType itemTrashType)
    {
        strikes += 1;
        print("Strikes: " + strikes);

        if (strikes > maxStrikes)
        {
            gameManager.OnGameOver();
        }
    }

}

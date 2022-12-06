using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public Action<TrashType> OnScore;
    public Action<TrashType, TrashType> OnIncorrect;

    public GameManager gameManager;
    public HeartDropper heartDropper;
    public float maxStrikes = 3;
    public float maxMisses = 2;

    public TextMeshProUGUI bestText, currentScoreText;

    int currentScore;
    int strikes;
    int currentMisses;
    private void Start()
    {
        OnScore += OnScoreOccurs;
        OnIncorrect += OnIncorrectOccurs;

        bestText.text = "Best: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    void OnScoreOccurs(TrashType trashType)
    {
        //Debug.Log(trashType.ToString());
        currentScore += 1;
        print("Current score: " + currentScore);
        currentScoreText.text = "Score: " + currentScore;

        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }

    void OnIncorrectOccurs(TrashType canTrashType, TrashType itemTrashType)
    {
        strikes += 1;
        print("Strikes: " + strikes);

        CheckScore();
    }

    public void OnMissOccurs()
    {
        currentMisses += 1;
        CheckScore();

    }
    void CheckScore()
    {
        heartDropper.Drop();
        if (currentMisses + strikes >= 5)
        {
            gameManager.OnGameOver();
        }
        //if (currentMisses > maxMisses)
        //{
        //    gameManager.OnGameOver();
        //}

        //if (strikes > maxStrikes)
        //{
        //    gameManager.OnGameOver();
        //}
    }

}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool fadeInAtStart = false;
    public Action OnGameOver;
    public Animator overlayCanvasAnimator;

    public Transform gameOverUI;

    public GameObject leftGrab, rightGrab, leftRay, rightRay;

    private void Start()
    {
        OnGameOver += OnGameOverOccurred;
        if (fadeInAtStart)
        {
            FadeIn();
        }
    }

    private void Awake()
    {
        
    }
    private void OnDisable()
    {
        OnGameOver -= OnGameOverOccurred;
    }

    void OnGameOverOccurred()
    {
        print("Game over");

        // show game over ui that says why you lost
        gameOverUI.gameObject.SetActive(true);
        leftGrab.SetActive(false);
        rightGrab.SetActive(false);

        leftRay.SetActive(true);
        rightRay.SetActive(true);
        
    }

    public void OnMainMenu()
    {
        GameManager.fadeInAtStart = true;
        LoadMainMenu();

    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void LoadMain()
    {
        SceneManager.LoadScene(1);
    }

    public void OnRestart()
    {
        GameManager.fadeInAtStart = true;
        FadeToBlack();
        Invoke(nameof(LoadMain), 1f);
        //SceneManager.LoadScene(1);
    }

    void FadeToBlack()
    {
        overlayCanvasAnimator.SetTrigger("FadeToBlack");
    }

    void FadeIn()
    {
        overlayCanvasAnimator.SetTrigger("FadeToTransparent");
    }

}

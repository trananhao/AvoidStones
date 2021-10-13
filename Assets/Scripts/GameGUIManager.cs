using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGui;
    public GameObject gameGui;
    public GameObject gameover;

    public Text scoreCountingText;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGameGui(bool isShow)
    {
        if (gameGui)
            gameGui.SetActive(isShow);

        if (homeGui)
            homeGui.SetActive(!isShow);
    }

    public void ShowGameover(bool isShow)
    {
        if (gameover)
            gameover.SetActive(isShow);
    }

    public void UpdateScoreCounting(int score)
    {
        if (scoreCountingText)
            scoreCountingText.text = "SCORE: x" + score.ToString("00");
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Application.Quit();
    }
}

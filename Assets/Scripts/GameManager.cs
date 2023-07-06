using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public Score score;
    public static bool gameStarted;
    public GameObject GetReady;
    public static int gameScore;
    public GameObject TopScore;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameHasStarted()
    {
        gameStarted = true;
        GetReady.SetActive(false);
    }

    public void GameOver()
    {
        score.UpdateScorePanel();
        gameScore = score.GetScore();
        gameOver = true;
        gameOverPanel.SetActive(true);
        TopScore.SetActive(false);

    }
}

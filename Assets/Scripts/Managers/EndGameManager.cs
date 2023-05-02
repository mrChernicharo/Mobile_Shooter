using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager instance;
    public bool gameOver = false;

    private PanelController panelController;

    private TextMeshProUGUI scoreText;
    private int score = 0;
    [HideInInspector]
    public string lvlUnlock = "LevelUnlock";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    public void StartResolveSequence()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }

    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2.5f);
        ResolveGame();
    }

    public void ResolveGame()
    {
        if (gameOver == false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        // score
        ScoreSet();
        // activate panel
        panelController.ActivateWinScreen();
        // unlock next level
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel > PlayerPrefs.GetInt(lvlUnlock, 0))
        {
            PlayerPrefs.SetInt(lvlUnlock, nextLevel);
        }
    }

    public void LoseGame()
    {
        ScoreSet();
        panelController.ActivateLoseScreen();
    }

    private void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score);
        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score);
        }

        score = 0;
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = $"Score: {score}";
    }

    public void RegisterPanelController(PanelController pc)
    {
        panelController = pc;
    }
    public void RegisterScoreText(TextMeshProUGUI text)
    {
        scoreText = text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager instance;
    public bool gameOver = false;

    private PanelController panelController;

    private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
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
        // activate panel
        panelController.ActivateWinScreen();
        // unlock next level
        // score
    }

    public void LoseGame()
    {
        panelController.ActivateLoseScreen();

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        int score = PlayerPrefs.GetInt("Score" + SceneManager.GetActiveScene().name, 0);
        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);

        scoreText.text = $"Score: {score}";
        highScoreText.text = $"HighScore: {highScore}";


    }
}

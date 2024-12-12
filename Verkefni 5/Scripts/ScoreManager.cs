using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    // Updatar scoreið
    public void UpdateScore(int points)
    {
        score += points; // bættir stig i score
        scoreText.text = "Score: " + score;
    }
}

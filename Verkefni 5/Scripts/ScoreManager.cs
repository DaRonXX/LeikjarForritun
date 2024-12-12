using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen; // Vísun á Game Over skjáinn
    public int score = 0;

    private void Start()
    {
        // Gakktu úr skugga um að Game Over skjárinn sé falinn í byrjun leiks
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOverScreen er ekki úthlutað í Inspector.");
        }
    }

    // Uppfærir stig
    public void UpdateScore(int points)
    {
        score += points; // Bætir stigum við
        scoreText.text = "Stig: " + score;

        // Athugar hvort stig séu undir 0
        if (score < 0)
        {
            ShowGameOverScreen();
        }
    }

    // Sýnir Game Over skjáinn
    private void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0; // Stöðvar leikinn
        }
    }
}

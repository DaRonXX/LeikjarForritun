using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Ef TextMeshPro er notað
// using UnityEngine.UI; // Aftengið ef þú notar venjulegan UI Text

public class PlayerHealth : MonoBehaviour
{
    public int health = 3; // Upphafs líf
    public GameObject gameOverScreen;
    public TextMeshProUGUI healthText; // Ef TextMeshPro er notað
    // public Text healthText; // Aftengið ef venjulegur UI Text er notaður

    void Start()
    {
        gameOverScreen.SetActive(false); // Felur Game Over skjá í byrjun
        UpdateHealthUI(); // Sýnir upphaflegt líf
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Athugar hvort leikmaður rekst á óvin
        {
            health -= 1;
            UpdateHealthUI(); // Uppfærir sýnilegt líf
            Debug.Log("Líf: " + health);

            if (health <= 0)
            {
                GameOver();
            }
        }
    }

    void UpdateHealthUI()
    {
        healthText.text = "Líf: " + health; // Uppfærir texta með lífum
    }

    void GameOver()
    {
        Time.timeScale = 0f; // Stöðvar leikinn
        gameOverScreen.SetActive(true); // Sýnir Game Over skjá
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Endurræsir tímann í leiknum
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Endurhleður núverandi senu
    }

    public void QuitGame()
    {
        Application.Quit(); // Lokar forritinu
        Debug.Log("Leikur hætt!");
    }
}

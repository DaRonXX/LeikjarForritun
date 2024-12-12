using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3; // lifið
    public GameObject gameOverScreen;

    void Start()
    {
        gameOverScreen.SetActive(false); // fellir gameover i vyrjun leiks
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            Debug.Log("Health: " + health);

            if (health <= 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f; // stoppar leikin
        gameOverScreen.SetActive(true); // sýnir GameOverScreen
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // byrjar leik
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reloadar senuna
    }

    public void QuitGame()
    {
        Application.Quit(); // stoppar leikin
        Debug.Log("Game Quit!");
    }
}

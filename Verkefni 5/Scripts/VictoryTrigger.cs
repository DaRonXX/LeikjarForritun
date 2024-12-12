using UnityEngine;
using UnityEngine.UI;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject victoryCanvas;  // beinir til victory screen (Canvas)
    public Button retryButton;        // beinir til retry button

    private void Start()
    {
        // passar að vicroty er fallið
        victoryCanvas.SetActive(false);

        retryButton.onClick.AddListener(RestartScene);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // sér ef player hefur snert ósýnilega objectið
        if (other.CompareTag("Player"))
        {
            ShowVictoryScreen();
        }
    }

    // Sýnir victory screen
    private void ShowVictoryScreen()
    {
        victoryCanvas.SetActive(true);  // Sýnir victory screen
    }

    // byrjar leikin up á nýtt
    private void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}

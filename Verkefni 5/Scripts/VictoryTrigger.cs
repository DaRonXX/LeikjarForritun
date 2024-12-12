using UnityEngine;
using UnityEngine.UI;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject victoryCanvas;  // Vísun á sigur skjáinn (Canvas)
    public Button retryButton;        // Vísun á retry hnappinn

    private void Start()
    {
        // Gakktu úr skugga um að sigur skjárinn sé falinn í byrjun
        victoryCanvas.SetActive(false);

        retryButton.onClick.AddListener(RestartScene); // Tengir hnappinn við að hefja leikinn aftur
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Athugar hvort spilarinn snerti ósýnilega hlutinn
        if (other.CompareTag("Player"))
        {
            ShowVictoryScreen(); // Sýnir sigur skjáinn
        }
    }

    // Sýnir sigur skjáinn
    private void ShowVictoryScreen()
    {
        victoryCanvas.SetActive(true);  // Sýnir sigur skjáinn
    }

    // Hefur leikinn aftur
    private void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); // Endurhlaðar núverandi vettvang
    }
}

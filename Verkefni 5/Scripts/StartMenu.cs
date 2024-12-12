using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu; // Vísun á start menu
    public Button startButton;   // Vísun á Start hnappinn
    public Button quitButton;    // Vísun á Quit hnappinn

    private void Start()
    {
        // Stoppar leikinn í byrjun
        Time.timeScale = 0f;

        startButton.onClick.AddListener(StartGame); // Tengir Start leik til að hefja leik
        quitButton.onClick.AddListener(QuitGame);   // Tengir Quit leik til að loka leik
    }

    private void StartGame()
    {
        // Byrjar leikinn
        Time.timeScale = 1f;

        // Felur start menu
        startMenu.SetActive(false);
    }

    private void QuitGame()
    {
        // Lokar leiknum
        Debug.Log("Lokar leik...");
        Application.Quit();
    }
}

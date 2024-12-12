using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu; // beinir til start menuið
    public Button startButton;   // beinir til Start button
    public Button quitButton;    // beinir til Quit button

    private void Start()
    {
        // pásar í byrjun
        Time.timeScale = 0f;

        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        // byrjar leik
        Time.timeScale = 1f;

        // fellur start menu
        startMenu.SetActive(false);
    }

    private void QuitGame()
    {
        // lokar leiknum
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
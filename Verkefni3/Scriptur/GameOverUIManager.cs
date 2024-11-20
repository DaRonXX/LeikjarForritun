using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverCanvas; // Vísun á Game Over Canvas
    public TextMeshProUGUI pointsText; // Vísun á texta sem sýnir stigin
    public MonoBehaviour cameraController; // Vísun á myndavélastýringarskript
    private bool isGameOver = false; // Breyta til að athuga hvort leikurinn sé yfir

    public AudioSource deathSound; // Vísun á dauðahljóð

    void Start()
    {
        gameOverCanvas.SetActive(false); // Fellir niður Game Over Canvas í upphafi
        Cursor.lockState = CursorLockMode.Locked; // Loka músarhorni í leik
        Cursor.visible = false; // Fela músarhornið í leik
    }

    public void ShowGameOverScreen()
    {
        if (isGameOver) return; // Ef leikurinn er þegar búinn, hætta við

        isGameOver = true; // Merki um að leikurinn sé búinn
        gameOverCanvas.SetActive(true); // Sýna Canvas
        pointsText.text = "Points: " + Kassi.count.ToString(); // Uppfæra texta með stigum
        Time.timeScale = 0f; // Pása leikinn

        // Spila dauðahljóð
        if (deathSound != null)
        {
            deathSound.Play(); // Spila hljóð þegar leikurinn endar
        }

        // Loka myndavélastýringum
        if (cameraController != null)
        {
            cameraController.enabled = false; // Slökkva á myndavélastýringum
        }

        // Vistastýring á músarhorni fyrir UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Sýna músarhornið fyrir UI
    }

    public void Retry()
    {
        Debug.Log("Retry button clicked"); // Úttak í console þegar reyna er
        Time.timeScale = 1f; // Setja tíma aftur í gang
        Cursor.lockState = CursorLockMode.Locked; // Loka músarhorni fyrir leik
        Cursor.visible = false; // Fela músarhornið
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Endurhlaða núverandi vettvang
    }

    public void Quit()
    {
        Debug.Log("Quit button clicked"); // Úttak í console þegar lokað er
        Time.timeScale = 1f; // Setja tíma aftur í gang áður en leikurinn er lokaður
        Application.Quit(); // Loka leiknum
    }
}

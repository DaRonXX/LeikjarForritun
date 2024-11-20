using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // Aðferð til að hefja leik
    public void PlayGame ()
    {
        // Hleður næstu sena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Aðferð til að hætta leik
    public void QuitGame ()
    {
        Debug.Log("HÆTTI LEIK!"); // Skrifar skilaboð í Console
        Application.Quit(); // Lokar leiknum
    }
}

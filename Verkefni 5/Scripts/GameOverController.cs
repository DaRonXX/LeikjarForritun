using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // Endurhleður núverandi leikjasenu
    public void RetryGame()
    {
        // Endurhleður núverandi senu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Hætta í leiknum
    public void QuitGame()
    {
        // Lokar forritinu (virkar aðeins í smíðuðu forriti, ekki í ritli)
        Application.Quit();
        
        // Fyrir prófun í ritlinum
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

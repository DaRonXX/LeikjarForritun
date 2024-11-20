using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameOverUIManager gameOverUIManager; // Vísun á GameOverUIManager skriptuna

    public void Start()
    {
        // Athugar hvort gameOverUIManager hafi verið úthlutað, ef ekki finnur það GameOverUIManager
        if (gameOverUIManager == null)
        {
            gameOverUIManager = FindObjectOfType<GameOverUIManager>();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // Ef leikmaður fer inn í svæði með "KillZone" tagi
        if (other.CompareTag("KillZone"))
        {
            Debug.Log("Leikmaður féll af brúninni og dó!"); // Skrifað í console þegar leikmaður deyr
            gameOverUIManager.ShowGameOverScreen(); // Kallar á fall sem birtir "Game Over" skjáinn
        }
    }
}

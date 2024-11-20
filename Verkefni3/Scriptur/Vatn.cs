using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vatn : MonoBehaviour
{
    public GameOverUIManager gameOverUIManager;
    private void OnTriggerEnter(Collider other)
    {
        // Ef leikmaður fer í gegn um vatnshindrun
        if (other.tag == "Player")
        {
            Debug.Log("Drukknaði"); // Skrifar út skilaboð þegar leikmaður fellur í vatn
            gameOverUIManager.ShowGameOverScreen(); // Kallar á fall sem birtir "Game Over" skjáinn
        }
    }
}

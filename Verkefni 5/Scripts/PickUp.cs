using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int points = 1; // Stig fyrir hvert PickUp

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Athugar hvort Player snerti hlutinn
        {
            FindAnyObjectByType<ScoreManager>().UpdateScore(points); // Bætir stigum við
            Destroy(gameObject); // Eyðir hlutnum
        }
    }
}

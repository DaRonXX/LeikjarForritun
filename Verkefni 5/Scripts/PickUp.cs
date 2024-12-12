using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int points = 1; // stikk fyrir hvert PickUp

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // til að sjá hvort Player snerti það
        {
            FindAnyObjectByType<ScoreManager>().UpdateScore(points); // bættir stig
            Destroy(gameObject); // eiðilegir gem steinnin
        }
    }
}

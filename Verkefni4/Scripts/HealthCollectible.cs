using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip; // Hljóð þegar hlut er safnað

    // Þegar leikmaður rekst á heilsusafn
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>(); // Finnur leikmannsstjórnanda

        // Athugar hvort leikmaðurinn getur bætt við heilsu
        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.PlaySound(collectedClip); // Spilar hljóð
            controller.ChangeHealth(1); // Bætir 1 við heilsuna
            Destroy(gameObject); // Eyðir safnhlutnum
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Þegar eitthvað er inni í skaðasvæðinu
    void OnTriggerStay2D(Collider2D other)
    {
        // Finnur leikmannsstjórnanda (PlayerController)
        PlayerController controller = other.GetComponent<PlayerController>();

        // Ef leikmaðurinn er til staðar, minnkar heilsuna um 1
        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    // Kallað þegar Projectile hlutinn er stofnaður
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Finnur Rigidbody2D hluti
    }

    // Keyrt á hverjum ramma
    void Update()
    {
        // Eyðir projectile ef það fer of langt frá upphafsstöðu
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    // Keyrt þegar projectile er skotið
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force); // Bætir krafti í ákveðna átt
    }

    // Keyrt þegar projectile rekst á annan hlut
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();

        // Athugar hvort projectile rakst á óvin og lagar hann
        if (enemy != null)
        {
            enemy.Fix();
        }

        Destroy(gameObject); // Eyðir projectile eftir árekstur
    }
}

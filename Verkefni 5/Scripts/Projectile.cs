using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // hendir projectile
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    // Detectar collision 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            // eiðileggir ovin
            Destroy(collision.collider.gameObject);
        }

        // eiðir projectile
        Destroy(gameObject);
    }

    // eiðir projectile eftir 2 sekondur
    void Start()
    {
        Destroy(gameObject, 2f);
    }
}

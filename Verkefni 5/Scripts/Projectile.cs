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

    // Hendir projektili í ákveðna stefnu með tilteknum krafti
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    // Greinir árekstur
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy")) // Ef árekstur er við óvin
        {
            // Eiðileggur óvininn
            Destroy(collision.collider.gameObject);
        }

        // Eiðileggur sjálft projectile
        Destroy(gameObject);
    }

    // Eiðileggur projectile eftir 2 sekúndur
    void Start()
    {
        Destroy(gameObject, 2f);
    }
}

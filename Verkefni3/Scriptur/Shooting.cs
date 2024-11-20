using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet; // Vísun á byssukúlu hlutinn
    public float speed = 3000f; // Hraði byssukúlu

    // Update is called once per frame
    void Update()
    {
        // Ef Z takki er ýtt á
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("skjOtttttttta"); // Prentar út skilaboð þegar byssan er skotin
           
            // Skapar nýja byssukúlu og staðsetur hana á núverandi stað
            GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>(); // Fáum Rigidbody frá kúlu
            instBulletRigidbody.AddForce(transform.forward * speed); // Setur hraða kúlu í stefnu fram á við
            Destroy(instBullet, 0.5f); // Eyðir kúlu eftir 0.5 sekúndur
        }
    }
}

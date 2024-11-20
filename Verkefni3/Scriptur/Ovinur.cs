using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ovinur : MonoBehaviour
{
    public static int health = 30; // Líf
    public Transform player; // Vísun á leikmanninn
    private TextMeshProUGUI texti; // Vísun á texta sem sýnir líf 
    private Rigidbody rb; // Vísun á Rigidbody fyrir hreyfingu óvins
    private Vector3 movement; // Hreyfingarvektorin
    public float hradi = 5f; // Hraði óvins

    void Start()
    {
        texti = GameObject.Find("Text2").GetComponent<TextMeshProUGUI>(); // Finna texta til að sýna líf óvins
        rb = this.GetComponent<Rigidbody>(); // Finna Rigidbody til að stjórna hreyfingu
        texti.text = "Líf " + health.ToString(); // Uppfæra texta með lífi óvins
    }

    void Update()
    {
        // Reiknar stefnu óvinsins gagnvart leikmanninum
        Vector3 stefna = player.position - transform.position;
        stefna.Normalize(); // Normalíserar stefnu vektorinn
        movement = stefna; // Uppfærir hreyfinguna
    }

    private void FixedUpdate()
    {
        // Kallar á hreyfingu í gegnum Rigidbody
        Hreyfing(movement);
    }

    void Hreyfing(Vector3 stefna)
    {
        // Hreyfir óvininn í átt að leikmanninum
        rb.MovePosition(transform.position + (stefna * hradi * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ef óvinur snertir leikmann
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Leikmaður fær í sig óvin"); // Skrifar út í console
            TakeDamage(10); // Kallar á TakeDamage með 10 skaða
            gameObject.SetActive(false); // Gerir óvininn óvirkan
        }
        // Ef óvinur verður fyrir kúlu
        if (collision.collider.tag == "kula")
        {
            Destroy(gameObject); // Eyðir óvininum
            gameObject.SetActive(false); // Gerir óvininn óvirkan
            Debug.Log("varð fyrir kúlu"); // Skrifar út í console
        }
    }

    public void TakeDamage(int damage)
    {
        // Uppfærir og prentar út líf óvins þegar hann tekur skaða
        Debug.Log("health er núna " + (health).ToString());
        health -= damage; // Dregur skaða frá lífi óvins
        texti.text = "Líf " + health.ToString(); // Uppfæra texta með nýju lífi
        if (health <= 0)
        {
            GameOver(); // Ef líf er núll eða lægra, kallar á GameOver
        }
    }

    void GameOver()
    {
        // Kallar á GameOverUIManager og birtir Game Over skjá
        GameOverUIManager gameOverUIManager = FindObjectOfType<GameOverUIManager>();
        if (gameOverUIManager != null)
        {
            gameOverUIManager.ShowGameOverScreen(); // Sýnir "Game Over" skjá
        }
    }
}

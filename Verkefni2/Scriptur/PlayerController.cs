using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // Tilvísun í Rigidbody hluti leikmannsins
    private int count; // Telur stig leikmannsins
    private float movementX; // X-hreyfing
    private float movementY; // Y-hreyfing
    public float speed = 0; // Hraði leikmannsins
    public TextMeshProUGUI countText; // Texti sem birtir stig
    public GameObject winTextObject; // Tilvísun í sigurskilaboð

    // Breytur fyrir stökkaðgerð
    private float jumpForce = 10.0f; // Kraftur fyrir stökk
    private bool isOnGround = true; // Athugar hvort leikmaðurinn sé á jörðinni

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Nær í Rigidbody hluti leikmannsins
        count = 0; // Núllstillir stig
        SetCountText(); // Uppfærir stigatexta
        winTextObject.SetActive(false); // Felur sigurskilaboð
    }

    void OnMove(InputValue movementValue)
    {
        // Nær í hreyfingu frá Input System
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; // Vista X-hreyfingu
        movementY = movementVector.y; // Vista Y-hreyfingu
    }

    private void FixedUpdate()
    {
        // Beitir krafti á leikmann fyrir hreyfingu
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void Update()
    {
        // Stökkva ef ýtt er á bilslá og leikmaðurinn er á jörðinni
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            isOnGround = false; // Merkja að leikmaður sé ekki lengur á jörðinni
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Athugar ef leikmaður snertir jörðina
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // Setur leikmann aftur á jörðina
        }
        // Athugar ef leikmaður snertir óvin
        if (collision.gameObject.CompareTag("Enemy"))
        {
            count -= 1; // Tapa stigi
            SetCountText(); // Uppfærir stigatexta
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Athugar ef leikmaður nær í hlutur með merkimiðanum "PickUp"
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); // Fjarlægir hlutinn
            count += 1; // Bætir við stigi
            SetCountText(); // Uppfærir stigatexta
        }
    }

    void SetCountText()
    {
        // Uppfærir texta með núverandi stigum
        countText.text = "Fjöldi: " + count.ToString();

        // Skiptir yfir í næstu sena ef 1 stig er náð í sena 1
        if (count == 1 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        // Sýnir "Þú vannst" ef 2 stig eru náð í sena 2
        else if (count == 2 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            winTextObject.SetActive(true); // Sýnir sigurskilaboð
            Time.timeScale = 0; // Stöðvar leikinn
        }
    }
}

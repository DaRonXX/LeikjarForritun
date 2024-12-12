using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public static int stig; // Stig leikmanns
    private TextMeshProUGUI countText;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public GameObject projectilePrefab;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        countText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>(); // Sækir stigatextann
        stig = 0; // Upphafsstig
        SetCountText(); // Uppfærir textann í byrjun
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        // Athugar hvort Ruby hreyfist og uppfærir stefnu
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        // Athugar hvort C-hnappurinn var ýttur til að skjóta
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
    }

    void FixedUpdate()
    {
        // Uppfærir stöðu Ruby út frá hreyfingu
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy")) // Ef Ruby rekst á óvin
        {
            stig -= 1; // Lækkar stig
            collision.collider.gameObject.SetActive(false); // Gerir óvin óvirkan
        }

        if (collision.collider.CompareTag("gim")) // Ef Ruby tekur gimstein
        {
            stig += 1; // Hækkar stig
            collision.collider.gameObject.SetActive(false); // Gerir gimstein óvirkan
        }

        SetCountText(); // Uppfærir stigatextann
    }

    void SetCountText()
    {
        countText.text = "Stig: " + stig.ToString(); // Sýnir nýjustu stigin
    }

    void Launch()
    {
        // Skýtur projektili í átt Ruby er að horfa
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 700);

        animator.SetTrigger("Launch"); // Keyrir Launch hreyfingu
    }
}

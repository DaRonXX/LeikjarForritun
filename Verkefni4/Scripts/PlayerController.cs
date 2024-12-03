using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Breytur fyrir hreyfingu leikmanns
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;

    // Breytur fyrir heilsukerfi
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;

    // Breytur fyrir tímabundna ósnertanleika
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    // Breytur fyrir hreyfimyndir (Animation)
    Animator animator;
    Vector2 moveDirection = new Vector2(1, 0);

    // Breytur fyrir skot
    public GameObject projectilePrefab;

    // Breytur fyrir hljóð
    AudioSource audioSource;

    // Keyrt einu sinni í byrjun leiks
    void Start()
    {
        MoveAction.Enable(); // Virkja inntaksaðgerðina
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // Byrjar með fulla heilsu
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Keyrt á hverjum ramma
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>(); // Læsir hreyfingargildi frá leikmanni

        // Athugar hvort leikmaður er að hreyfa sig og uppfærir stefnu
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }

        animator.SetFloat("Look X", moveDirection.x); // Uppfærir sjónstefnu X
        animator.SetFloat("Look Y", moveDirection.y); // Uppfærir sjónstefnu Y
        animator.SetFloat("Speed", move.magnitude); // Uppfærir hraða

        // Ef ósnertanleiki er virkur
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false; // Lýkur ósnertanleika
            }
        }

        // Skýtur ef C er ýtt
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        // Leitar að félaga ef X er ýtt
        if (Input.GetKeyDown(KeyCode.X))
        {
            FindFriend();
        }
    }

    // Keyrt á fast hraða í takt við eðlisfræði kerfið
    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime; // Reiknar nýja stöðu
        rigidbody2d.MovePosition(position); // Færir leikmann
    }

    // Breytir heilsu leikmanns
    public void ChangeHealth(int amount)
    {
        if (amount < 0) // Ef leikmaður tekur skaða
        {
            if (isInvincible)
            {
                return; // Hunsar ef leikmaður er ósnertanlegur
            }
            isInvincible = true; // Gerir leikmann ósnertanlegan
            damageCooldown = timeInvincible; // Endurstillir tímabundinn ósnertanleika
            animator.SetTrigger("Hit"); // Keyrir högg hreyfingu
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); // Uppfærir heilsu innan marka
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth); // Uppfærir heilsustikuna
    }

    // Skýtur verkefni (projectile)
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(moveDirection, 300); // Skýtur í valda átt
        animator.SetTrigger("Launch"); // Keyrir skot hreyfingu
    }

    // Leitar að félaga (NPC)
    void FindFriend()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
            if (character != null)
            {
                UIHandler.instance.DisplayDialogue(); // Sýnir samtal
            }
        }
    }

    // Spilar hljóð
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Opinberar breytur
    public float speed; // Hraði óvinarins
    public bool vertical; // Stjórnar hvort óvinurinn hreyfist lóðrétt
    public float changeTime; // Tími þar til óvinurinn skiptir um stefnu
    public ParticleSystem smokeEffect; // Reykhrif þegar óvinurinn er lagaður

    // Einkabreyta
    Rigidbody2D rigidbody2d; // RigidBody fyrir hreyfingu
    Animator animator; // Animator fyrir óvinar hreyfingar
    float timer; // Teljari fyrir tímamælingu
    int direction = 1; // Stefna hreyfingar (1 eða -1)
    bool broken = true; // Athugar hvort óvinurinn sé bilaður

    // Keyrt einu sinni í byrjun leiks
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Sækir Rigidbody2D hluta
        animator = GetComponent<Animator>(); // Sækir Animator hluta
        timer = changeTime; // Upphafsstillir tímann
    }

    // Keyrt á hverjum ramma
    void Update()
    {
        timer -= Time.deltaTime; // Minnkar tímann

        if (timer < 0) // Ef tímamælirinn er búinn
        {
            direction = -direction; // Skiptir um stefnu
            timer = changeTime; // Endurstillir tímann
        }
    }

    // Keyrt með sama hraða og eðlisfræði kerfið
    void FixedUpdate()
    {
        if (!broken) // Ef óvinurinn er lagaður, hætta
        {
            return;
        }

        Vector2 position = rigidbody2d.position; // Nær í núverandi stöðu

        if (vertical) // Ef óvinurinn hreyfist lóðrétt
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else // Ef óvinurinn hreyfist lárétt
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigidbody2d.MovePosition(position); // Uppfærir stöðu
    }

    // Þegar óvinurinn rekst á leikmann
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null) // Ef leikmaður finnst
        {
            player.ChangeHealth(-1); // Minnkar heilsu leikmanns
        }
    }

    // Aðferð til að laga óvininn
    public void Fix()
    {
        broken = false; // Setur óvininn í lagfærðan ham
        rigidbody2d.simulated = false; // Stöðvar eðlisfræði fyrir óvin
        animator.SetTrigger("Fixed"); // Keyrir lagaðan hreyfingu
        smokeEffect.Stop(); // Stöðvar reykáhrif
    }
}

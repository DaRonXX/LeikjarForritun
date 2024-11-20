using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Kassi : MonoBehaviour
{
    public static int count = 0; // Breyta til að halda utan um stigin
    public GameObject sprenging; // Vísun á sprengingu sem verður búin til
    private TextMeshProUGUI countText; // Vísun á texta sem sýnir stigin

    void Start()
    {
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>(); // Finna Text hluta sem fer með stig
        count = 0; // Byrjar stigafjölda á 0
        SetCountText(); // Uppfærir stigatextann
    }

    private void Update()
    {
        // Ef kassi fer undir ákveðna hæð, eyða honum
        if (transform.position.y < -10)
        {
            Destroy(gameObject); // Eyðir kassanum
            gameObject.SetActive(false); // Gerir kassann óvirkan
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ef kassi snertir hlut með "kula" tagi
        if (collision.collider.tag == "kula")
        {
            Destroy(gameObject); // Eyðir kassanum
            gameObject.SetActive(false); // Gerir kassann óvirkan
            Debug.Log("varð fyrir kúlu"); // Skrifar út skilaboð þegar kassi verður fyrir kúlu
            count = count + 1; // Bætir við stigi
            SetCountText(); // Kallar á aðferðina til að uppfæra stigatextann
            Sprengin(); // Kallar á sprengingu
        }
    }

    void SetCountText() // Aðferð til að uppfæra stigatextann
    {
        countText.text = "Stig: " + count.ToString(); // Uppfærir textann með nýjum stigum
    }

    void Sprengin()
    {
        Instantiate(sprenging, transform.position, transform.rotation); // Býr til sprengingu á sama stað og kassi
    }
}

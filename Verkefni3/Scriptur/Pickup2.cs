using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pickup2 : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI countText; // Vísun á texta sem sýnir stig

    void Start()
    {
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>(); // Finna Text hluta fyrir stig
        SetCountText(); // Uppfærir stigatextann
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        // Ef leikmaður snertir hlutinn (með tag "Player")
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject); // Eyðir pickup hlutnum
            gameObject.SetActive(false); // Gerir hlutinn óvirkan
            Debug.Log("varð fyrir kúlu"); // Skrifar út skilaboð þegar hlutinn er tekinn
            Kassi.count = Kassi.count + 10; // Bætir 10 stigum við
            SetCountText(); // Kallar á aðferðina til að uppfæra stigatextann
        }
    }

    void SetCountText() // Aðferð til að uppfæra stigatextann
    {
        countText.text = "Stig: " + Kassi.count.ToString(); // Uppfærir textann með nýjum stigum
    }
}

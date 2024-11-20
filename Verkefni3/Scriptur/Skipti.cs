using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    void Start()
    {
        Debug.Log("byrja"); // Skrifar út skilaboð þegar leikurinn byrjar
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false); // Gerir hlut óvirkan þegar hann snertir viðbragðsflöt
        StartCoroutine(Bida()); // Hefur biðröð sem bíður í 3 sekúndur áður en næsta sena byrjar
    }

    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3); // Bíður í 3 sekúndur
        Endurræsa(); // Kallar á Endurræsa aðferðina eftir 3 sekúndur
    }

    public void Endurræsa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Hleður næstu senunni í leiknum
    }
}

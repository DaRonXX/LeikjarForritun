using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Takki : MonoBehaviour
{
    private void Update()
    {
        Cursor.visible = true; // Sýnir músarmarkið
        Cursor.lockState = CursorLockMode.None; // Læsir ekki músarmarkinu
    }

    public void Byrja()
    {
        SceneManager.LoadScene(1); // Hleður fyrstu senunni (Scene 1) þegar takki er ýtt
    }

    public void Endir()
    {
        SceneManager.LoadScene(0); // Hleður fyrri senunni (Scene 0), t.d. main menu
    }
}

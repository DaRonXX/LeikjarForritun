using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Klikk : MonoBehaviour
{
    public void Byrja() // Aðferð til að byrja leikinn
    {
        SceneManager.LoadScene(1); // Hleður upp fyrsta vettvangi (Scene 1)
    }
}

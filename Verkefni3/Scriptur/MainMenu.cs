using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame () // Aðferð til að byrja leikinn
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); // Hleður næsta vettvangi (Scene) asynkrónískt
    }

    public void QuitGame () // Aðferð til að loka leiknum
    {
        Debug.Log("Game Quit"); // Skrifar út skilaboð í console þegar leikurinn er lokaður
        Application.Quit(); // Loka leiknum
    }
}

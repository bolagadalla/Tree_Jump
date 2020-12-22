using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public AudioSource clickSoundEffect;
    public bool pauseMenuActive = false;

    /// <summary>
    /// It will pause the game and show the pause menu
    /// </summary>
    public void PauseButtonPressed()
    {
        // Checks it if its false
        if (!pauseMenuActive)
        {
            StartCoroutine(ClickEffect());
            pausePanel.SetActive(true);
            pauseMenuActive = true;
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Once pressed it will resume the game and deactivate the pause menu
    /// </summary>
    public void ResumePlayButton()
    {
        StartCoroutine(ClickEffect());
        Time.timeScale = 1;
        pauseMenuActive = false;
        pausePanel.SetActive(false);
    }

    /// <summary>
    /// It will reload the scene
    /// </summary>
    public void ReplayButton()
    {
        StartCoroutine(ClickEffect());
        pauseMenuActive = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Quits the game play to the main menu
    /// </summary>
    public void QuitToMainMenu()
    {
        StartCoroutine(ClickEffect());
        Time.timeScale = 1;
        pauseMenuActive = false;
        pausePanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Delay the scene by how much seconds you want
    /// </summary>
    /// <returns></returns>
    IEnumerator ClickEffect()
    {
        clickSoundEffect.Play();
        yield return new WaitForSeconds(clickSoundEffect.time + 0.1f);
        // Or here you can enter the code to load the scene you want after the seconds.
        // And then start the corountine in the scene method you want.
    }
}

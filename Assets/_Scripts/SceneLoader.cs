using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Seconds delayed until the next scene is loaded.
    public float secondsDelayed = 2f;
    public AudioSource clickSoundEffect;

    /// <summary>
    /// Load the next scene, by using the current index number + 1.
    /// </summary>
    public void LoadNextScene()
    {
        StartCoroutine(ClickEffect());
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    /// <summary>
    /// Load specific scenes by puting their index number as a parameter
    /// </summary>
    /// <param name="SceneIndex"> The index number of the scene </param>
    public void LoadScenes(int SceneIndex)
    {
        StartCoroutine(ClickEffect());
        SceneManager.LoadScene(SceneIndex);
    }

    /// <summary>
    /// Use to start the first scene that you have.
    /// </summary>
    public void LoadStartScene()
    {
        StartCoroutine(ClickEffect());
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Reloads current scene
    /// </summary>
    public void ReloadCurrentScene()
    {
        StartCoroutine(ClickEffect());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Use to quit the game, this will only work when it is stand alone
    /// </summary>
    public void QuitGame()
    {
        StartCoroutine(ClickEffect());
        Application.Quit();
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

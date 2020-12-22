using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [Header("Variables")]
    //Variables
    private bool pausedMenuShow = false;

    [Header("Cached Components")]
    //Cached Components
    public GameObject pausePanel;   // Pause panel
    public GameObject deathPanel;   // Death panel
    public GameObject homePanel;    // Home page
    public GameObject playPanel;    // Play page
    public GameObject shopPanel;    // Shop page
    public GameObject settingPanel; // Setting page

    ///<summary>
    /// Pause the game by setting the time scale to 0 and show the pause panel
    ///<summary>
    public void PauseGame()
    {
        pausedMenuShow = true;
        if (pausedMenuShow)
        {
            Time.timeScale = 0f; // Sets the time scale to 0 so everything is paused
            pausePanel.SetActive(true); // Sets the pause panel to active
        }
        else
        {
            pausedMenuShow = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }

    ///<summary>
    /// Resumes the game by setting the pause panel to false and time scale back to 1
    ///<summary>
    public void ResumeGame()
    {
        pausePanel.SetActive(false); // Deactivate the pause panel
        Time.timeScale = 1; // Sets the time scale back to 1
        pausedMenuShow = false; // Sets the bool to false, maybe will use later, if not we delete it
    }

    //Instead we can reload the game scene then we keep the home panel turned off
    ///<summary>
    /// Sends the player to the scene with index 0
    ///<summary>
    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the game scene
        Time.timeScale = 1; // its to make sure that the game is runned at a normal speed
    }

    /// <summary>
    /// Reloads the current scene
    /// <summary>
    public void ReloadGame() // This needs fixing, the panels are not activated right
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the game scene
        homePanel.SetActive(false); // Deactivates the home panel
        playPanel.SetActive(true);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Once pressed it will start the game and the game scene
    /// <summary>
    public void PlayGame()
    {
        Time.timeScale = 1;
        // Deactivate the home scene
        homePanel.SetActive(false);

        // Activate the play panel
        playPanel.SetActive(true);

        // Desplay counter
    }

    #region Shop Page
    /// <summary>
    /// Open the shop panel
    /// <summary>
    public void OpenShop()
    {
        shopPanel.SetActive(true);
        homePanel.SetActive(false);
    }
    /// <summary>
    /// Close the shop panel
    /// <summary>
    public void CloseShop()
    {
        shopPanel.SetActive(false);
        homePanel.SetActive(true);
    }
    #endregion

    #region Setting Page
    /// <summary>
    /// Opens the setting page
    /// <summary>
    public void OpenSetting()
    {
        settingPanel.SetActive(true); // activates the setting panel
        homePanel.SetActive(false);
    }
    /// <summary>
    /// Closes the setting page
    /// <summary>
    public void CloseSetting()
    {
        settingPanel.SetActive(false);
        homePanel.SetActive(true);
    }
    #endregion

    
}

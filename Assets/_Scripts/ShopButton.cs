using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] GameObject homeScreen;
    [SerializeField] GameObject shopScreen;
    
    /// <summary>
    /// Activates the Shop Screen and deactivates the Home Screen
    /// </summary>
    public void ShopButtonPressed()
    {
        homeScreen.SetActive(false);
        shopScreen.SetActive(true);
    }

    /// <summary>
    /// Activates the Home Screen and deactivates the Shop Screen
    /// </summary>
    public void ShopBackButtonPressed()
    {
        homeScreen.SetActive(true);
        shopScreen.SetActive(false);
    }
}

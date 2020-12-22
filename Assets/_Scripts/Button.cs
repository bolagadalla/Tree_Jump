using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
    [SerializeField] int sceneIndex;

    SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void OnMouseDown()
    {
        sceneLoader.LoadScenes(sceneIndex);
    }


}

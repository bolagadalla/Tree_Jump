using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI highscoreTextOnDeathPanel;

    public TextMeshProUGUI scoreText;
    public Player player;

    // private static ScoreManager instance;
    // public static ScoreManager Instance
    // {
    //     get
    //     {
    //         if (instance == null)
    //         {
    //             instance = FindObjectOfType<ScoreManager>();
    //         }
    //         return instance;
    //     }
    // }

    private void Start() 
    {
        highscoreText.text = "HIGHSCORE:\n" + PlayerPrefs.GetFloat("HIGHSCORE").ToString();
        highscoreTextOnDeathPanel.text = "HIGHSCORE:\n" + PlayerPrefs.GetFloat("HIGHSCORE").ToString();
    }
    // Update is called once per frame
    void Update()
    {
        AddScore();
    }

    /// <summary>
    /// Adds score and saves highscore
    /// <summary>
    public void AddScore()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.y > 0 && player.transform.position.y > score)
        {
            score = player.transform.position.y;
        }
        scoreText.text = Mathf.Round(score).ToString() + " ft";

        if (score > PlayerPrefs.GetFloat("HIGHSCORE", 0))
        {
            PlayerPrefs.SetFloat("HIGHSCORE", Mathf.Round(score));
            highscoreText.text = "HIGHSCORE:\n" + PlayerPrefs.GetFloat("HIGHSCORE").ToString();
            highscoreTextOnDeathPanel.text = "HIGHSCORE:\n" + PlayerPrefs.GetFloat("HIGHSCORE").ToString();
        }
    }
}

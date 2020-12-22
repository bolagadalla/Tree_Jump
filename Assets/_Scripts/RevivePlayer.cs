using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RevivePlayer : MonoBehaviour
{
    public int offset = 5;

    public Transform player;
    public GameObject deathPanel;
    public GameObject reviveButton;
    public CountdownDelay countdownDelay;
    public AudioSource clickSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > transform.position.y)
        {
            // Make a new vector3 position where every axis is the same, but the y axis will equal to the target y axies
            Vector3 newPos = new Vector3(transform.position.x, player.position.y, transform.position.z);
            // Move this object to the new position
            transform.position = newPos;
        }
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // Your code to reward player
                RevivePlayerButton();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                // Your code to tell player that the add was skipped
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }


    /// <summary>
    /// Once its called it will translate the player to the current revive point plus an offset and play the Ready Go! animation
    /// </summary>
    public void RevivePlayerButton()
    {
        StartCoroutine(ClickEffect());
        player.transform.position = new Vector3(transform.position.x, transform.position.y + offset, player.transform.position.z);
        StartCoroutine(DelayToReleasePlayer(3));
        countdownDelay.Countdown();

    }

    IEnumerator DelayToReleasePlayer(int delayTime)
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        deathPanel.SetActive(false);
        Destroy(reviveButton);
        yield return new WaitForSeconds(delayTime);
        countdownDelay.countdownPanel.gameObject.SetActive(false);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
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

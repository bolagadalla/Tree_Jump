using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownDelay : MonoBehaviour
{
    public GameObject countdownPanel;
    public GameObject numbers;

    private Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        animator = numbers.GetComponent<Animator>();
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Once this function is called it will count down again
    /// </summary>
    public void Countdown()
    {
        countdownPanel.gameObject.SetActive(true);
        StartCoroutine(ReviveDelay());
    }

    IEnumerator StartDelay()
    {
        // Setting the time scale to 0
        Time.timeScale = 0;
        // Recording our pauseTime
        float pauseTime = Time.realtimeSinceStartup + 4f;

        while (Time.realtimeSinceStartup < pauseTime)
        {
            //Do nothing
            yield return 0;
        }
        // Deactivating our panel
        countdownPanel.gameObject.SetActive(false);
        // Returning the time scale back to normal = 1
        Time.timeScale = 1;
    }

    IEnumerator ReviveDelay()
    {
        animator.Play(0);
        yield return new WaitForSeconds(4.5f);
    }
}

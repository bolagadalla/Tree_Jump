using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    public GameObject deathPanel;
    public AudioSource deathSoundEffect;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            deathSoundEffect.Play();
            deathPanel.SetActive(true);
        }
    }
}

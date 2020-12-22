using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public bool flyingWings;
    private float flyForce = 50f;
    public int chanceOfSpawn;
    public int scoreForSpawn;
    public GameObject wings;
    public AudioSource powerupSoundEffect;


    public float powerupDuration;
    private static Powerup instance;

    // Singleton so you can call it from other scripts
    public static Powerup Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Powerup>();
            }
            return Powerup.instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (flyingWings)
            {
                Debug.Log("Player touched the flyahead powerup");
                FlyingWings(other);
            }
        }

    }

    public void FlyingWings(Collider2D other)
    {
        PowerupRandomSpawn();
        powerupSoundEffect.Play();

        for (int i = 0; i < flyForce; i++)
        {
            other.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
            TreeSpawn.Instance.SpawnTree();
        }
        Destroy(gameObject,3f);
    }

    public void PowerupRandomSpawn()
    {
//        if (Player.Instance.score >= scoreForSpawn)
//        {
//            int randomPercantage = Random.Range(0, 100);
//            if (randomPercantage <= chanceOfSpawn)
//            {
//                gameObject.GetComponent<SpriteRenderer>().enabled = true;
//                gameObject.GetComponent<Collider2D>().enabled = true;
//            }
//        }
    }
}

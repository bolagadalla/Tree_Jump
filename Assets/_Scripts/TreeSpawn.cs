using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    public int spawnCount;
    public GameObject[] nextTreeToSpawn;
    public GameObject baseTree;

    private static TreeSpawn instance;

    // Singleton so you can call it from other scripts
    public static TreeSpawn Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TreeSpawn>();
            }
            return TreeSpawn.instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnTree();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTree()
    {
        // Generates a random number in the index
        int randomIndex = Random.Range(0, nextTreeToSpawn.Length);

        // Spawns a new tree at a random index
         baseTree = Instantiate(nextTreeToSpawn[randomIndex], baseTree.transform.GetChild(0).position, Quaternion.identity) as GameObject;

        Powerup.Instance.PowerupRandomSpawn();
    }
}

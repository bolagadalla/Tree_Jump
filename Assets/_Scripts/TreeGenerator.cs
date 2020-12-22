using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    [Header("Variables")]
    public int spawnAmount = 20;
    public GameObject[] treesToSpawn;
    public GameObject baseTree;
    public GameObject treeWilBeSpawned;
    public List<GameObject> treeList = new List<GameObject>();

    // private static TreeGenerator instance;
    // public static TreeGenerator Instance
    // {
    //     get
    //     {
    //         if (instance == null)
    //         {
    //             instance = FindObjectOfType<TreeGenerator>();
    //         }
    //         return instance;
    //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
        SpawnInitalTrees(); // Spawns the inital trees
        for (int i = 0; i < spawnAmount; i++)
        {
            SpawnTreesToList();
        }
    }

    /// <summary>
    /// This will spawn the inital trees that will appear on the screen
    /// </summary>
    public void SpawnInitalTrees()
    {
        // This for loop will loop to create trees, the same amount as spawnAmount
        for (int i = 0; i <= spawnAmount; i++)
        {
            int randomIndex = Random.Range(0, treesToSpawn.Length); // This creates a random number from 0 to the length of the list

            // Spawns a tree prefab and assign it to the baseTree with the transform of the first child object on the base tree. 
            // Every time it spawns a tree it spawns it on the basetree first child position. this will basically stack on top of eachother
            baseTree = Instantiate(treesToSpawn[randomIndex], baseTree.transform.GetChild(0).position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Spawns trees to the list
    /// </summary>
    public void SpawnTreesToList()
    {
        // Creating a random index for the trees in the list
        int randomIndex = Random.Range(0, treesToSpawn.Length);
        // Instantiating a gameObject and assign it to the variable spawnedTree
        var spawnedTrees = Instantiate(treesToSpawn[randomIndex], transform.position, Quaternion.identity);
        // Adds the gameObject that was just spawned
        treeList.Add(spawnedTrees);
        // Sets the gameObject to be deactive
        spawnedTrees.SetActive(false);
    }
    
    /// <summary>
    /// Spawns a tree on top of the baseTree and reassigning the new spawned tree to the baseTree
    /// </summary>
    public void SpawnTree()
    {
        int randomIndex = Random.Range(0, treeList.Count); // Creates a random integer to pick from the list
        treeWilBeSpawned = treeList[randomIndex]; // Assign the randomly picked gameObject to the treeWillBeSpawned variable
        treeWilBeSpawned.SetActive(true); // Sets that gameObject to be active
        treeWilBeSpawned.transform.position = baseTree.transform.GetChild(0).position; // Change the position of the tree to be the same position as the gameObject first child position
        baseTree = treeWilBeSpawned; // Make the gameObject that was just "Spawned" to be the new baseTree for the next Spawning
        treeList.Remove(baseTree); // Removes the gameObject that was "Spawned" from the list
    }

    /// <summary>
    /// Once the Tree touches the collider it will be added back to the list
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            other.gameObject.SetActive(false); // Sets the gameObject deactive
            treeList.Add(other.gameObject); // Adds the gameObject to the list
            SpawnTree(); // Spawns a tree prefab
        }
    }
}

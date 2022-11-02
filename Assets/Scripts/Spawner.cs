using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // How quickly to spawn prefabs
    public float InitialSpawnDelay;

    // How much to decrease the spawn delay each time
    public float SpawnDelayDecrement;

    // What is the fastest we spawn prefabs
    public float MinSpawnDelay;

    // How much time elapsed after spawn
    private float elapsedTime;

    // The current spawn delay
    private float currSpawnDelay;

    // The location to spawn prefabs at
    public Transform spawnAnchor;

    // The available prefabs to choose from
    public GameObject[] availablePrefabs;

    private List<GameObject> spawnedObjectsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
        currSpawnDelay = InitialSpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= currSpawnDelay) {
            elapsedTime = 0;
            currSpawnDelay = Mathf.Max(currSpawnDelay - SpawnDelayDecrement, MinSpawnDelay);
            InitRandom();
        }
    }


    void InitRandom() {
        GameObject prefab = availablePrefabs[Random.Range(0, availablePrefabs.Length)];
        GameObject newObj = Instantiate(prefab, spawnAnchor.position, Quaternion.identity);
        spawnedObjectsList.Add(newObj);
    }

    public GameObject GetLastObject()
    {
        GameObject ob = spawnedObjectsList[0];
        spawnedObjectsList.RemoveAt(0);
        return ob;
    }
}

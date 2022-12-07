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
    public GameObject[] trashPrefabs, compostPrefabs, recyclePrefabs;

    private List<GameObject> spawnedObjectsList = new List<GameObject>();

    private float[] spawnDelayList = { 3, 2, 1 };
    int totalSpawns = 0;
    private int[] whenToChangeSpawnDelay = { 5, 15, 30 };
    private int indexOfWhenToChange = 0;
    // Start is called before the first frame updateS
    void Start()
    {
        elapsedTime = 0;
        currSpawnDelay = spawnDelayList[indexOfWhenToChange];
    }

    public int GetTotalSpawns()
    {
        return totalSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= currSpawnDelay) {
            elapsedTime = 0;
        
            InitRandom();
            // if it's time to change the spawn delay
            if (indexOfWhenToChange < spawnDelayList.Length-1 && totalSpawns == whenToChangeSpawnDelay[indexOfWhenToChange])
            {
                indexOfWhenToChange += 1;
                currSpawnDelay = spawnDelayList[indexOfWhenToChange];
                Debug.Log("Change spawn delay to " + currSpawnDelay);
            }
        }
    }


    void InitRandom() {
        GameObject prefab;
        int randNum = Random.Range(0, 3);
        if (randNum == 0)
        {
            prefab = trashPrefabs[Random.Range(0, trashPrefabs.Length)];
        }
        else if (randNum == 1)
        {
            prefab = recyclePrefabs[Random.Range(0, recyclePrefabs.Length)];
        }
        else
        {
            prefab = compostPrefabs[Random.Range(0, compostPrefabs.Length)];
        }


        GameObject newObj = Instantiate(prefab, spawnAnchor.position, Quaternion.identity);
        totalSpawns += 1;
        spawnedObjectsList.Add(newObj);
    }

    public GameObject GetLastObject()
    {
        GameObject ob = spawnedObjectsList[0];
        spawnedObjectsList.RemoveAt(0);
        return ob;
    }
}

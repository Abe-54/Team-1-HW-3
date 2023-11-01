using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomLogic : MonoBehaviour
{
    public GameObject ghostPrefab;
    public Transform[] spawnPoints;

    public int currentWave = 0;

    private int[] ghostsToKillForWaves = { 3, 5, 8 };
    public int numOfGhostKilled = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentWave == 0)
        {
            return;
        }

        if (currentWave < ghostsToKillForWaves.Length && numOfGhostKilled >= ghostsToKillForWaves[currentWave - 1])
        {
            Debug.Log("Wave " + currentWave + " completed.");
            SpawnWave();
        }
    }
    public void SpawnGhosts(int numGhosts, float ghostSpeed, float ghostHealth, float scaleMultiplier = 1f, bool shouldDropKey = false)
    {
        for (int i = 0; i < numGhosts; i++)
        {
            GameObject ghost = Instantiate(ghostPrefab, spawnPoints[i].position, Quaternion.identity);
            ghost.transform.localScale *= scaleMultiplier;
            ghost.GetComponent<GhostController>().speed = ghostSpeed;
            ghost.GetComponent<GhostController>().health = ghostHealth;

            if (shouldDropKey)
            {
                ghost.GetComponent<GhostController>().shouldDropKey = true;
            }
        }
    }

    public void IncreaseGhostsKilled()
    {
        numOfGhostKilled++;
    }

    public void ResetWaves()
    {
        currentWave = 0;
        numOfGhostKilled = 0;
    }

    public void SpawnWave()
    {
        switch (currentWave)
        {
            case 0:
                SpawnGhosts(3, 1f, 10f);
                break;
            case 1:
                SpawnGhosts(3, 1.5f, 20f);
                SpawnGhosts(2, 1f, 50f, 1.5f);
                break;
            case 2:
                SpawnGhosts(4, 1.5f, 75f);
                SpawnGhosts(3, 1.21f, 100f, 1.5f);
                SpawnGhosts(1, 0.8f, 150, 2f, true);
                break;
            default:
                Debug.Log("Wave not recognized.");
                break;
        }

        currentWave++;
        numOfGhostKilled = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [Header("Values")]
    public float spawnInterval;
    private Coroutine spawning;

    [System.Serializable]
    public class SpawnPoints
    {
        public Transform spawnPoint;
        public bool isEmpty;
    }

    public List<SpawnPoints> spawnPoints; 
    private List<SpawnPoints> emptySpawnPoints;
    public List<GameObject> buildings;

    // Start is called before the first frame update
    void Start()
    {
        emptySpawnPoints = new List<SpawnPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning == null)
        {
            spawning = StartCoroutine(clockSpawner(spawnInterval));
        }
    }

    private IEnumerator clockSpawner(float time)
    {
        yield return new WaitForSeconds(time);
        SpawnBuilding();
        spawning = null;
    }

    public void SpawnBuilding()
    {
        CheckSpawnPoints();
        if (emptySpawnPoints.Count > 0)
        {
            Instantiate(buildings[(Random.Range(0, buildings.Count))], emptySpawnPoints[(Random.Range(0, emptySpawnPoints.Count))].spawnPoint);
            Debug.Log(emptySpawnPoints.Count);
        }
    }

    public void CheckSpawnPoints()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[i].spawnPoint.childCount < 1 && spawnPoints[i].isEmpty == false)
            {
                emptySpawnPoints.Add(spawnPoints[i]);
                spawnPoints[i].isEmpty = true;
            }
        }

        for (int i = 0; i < emptySpawnPoints.Count; i++)
        {
            if (emptySpawnPoints[i].spawnPoint.childCount > 0 && emptySpawnPoints[i].isEmpty == true)
            {
                emptySpawnPoints[i].isEmpty = false;
                emptySpawnPoints.RemoveAt(i);
            }
        }
    }
}

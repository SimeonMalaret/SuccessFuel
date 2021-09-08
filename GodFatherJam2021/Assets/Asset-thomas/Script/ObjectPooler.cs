using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    /// <summary>
    ///vidéo de référence  https://www.youtube.com/watch?v=tdSmKaJvCoA
    ///je sais pas si ce que j'ai fais est exploitable car j'ai juste suivis la vidéo :/ mais j'ai appris des trucs
    ///il y a des chose que je j'ai tres peut utiliser que donc que je ne comprend pas commen par exemple les dictionnaires 
    /// </summary>
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;
     void Awake()
    { 
        Instance = this;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) // pour bien instantiate le bon nombre renseigner dans class sur l'éditeur
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();//créé une queue 
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);// on ajoute la pool au dictionnaire
        }

    }
    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag +"doesn't exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}

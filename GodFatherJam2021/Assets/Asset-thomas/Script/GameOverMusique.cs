using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMusique : MonoBehaviour
{
    public GameObject soundManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        soundManager.SetActive(false); 
    }
}

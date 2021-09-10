using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelItem : Items
{
    public int refuelNumber;

    public AudioSource audioSource;
    public AudioClip soundEffect;
    public GameObject fuelGraph;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(soundEffect);
            if (GameManager._instance.fuel > -40 + refuelNumber)
            {
                GameManager._instance.fuel -= refuelNumber;
            }

            fuelGraph.SetActive(false);
            Destroy(this.gameObject, 1f);
        }
    }
}

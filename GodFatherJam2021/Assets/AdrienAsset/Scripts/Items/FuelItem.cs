using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelItem : Items
{
    public int refuelNumber;

    public AudioSource audioSource;
    public AudioClip soundEffect;
    public GameObject mR;
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
            mR.SetActive(false);
            Destroy(this.gameObject, 1f);
        }
    }
}

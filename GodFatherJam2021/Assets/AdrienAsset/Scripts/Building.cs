using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundEffect;
    public void OnTriggerEnter(Collider other)
    {
        audioSource = GetComponent<AudioSource>();

        soundEffect = GameManager._instance.buildBump;
        audioSource.PlayOneShot(soundEffect);
        Debug.Log(soundEffect);
        if (other.tag == "Player")
        {
            GameManager._instance.FuelHit(GameManager._instance.buildingDamage, 0.5f);
        }
    }
}

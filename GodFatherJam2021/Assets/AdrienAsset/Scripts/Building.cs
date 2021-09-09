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
        //audioSource.PlayOneShot(soundEffect);
        soundEffect = GameManager._instance.buildBump;
        audioSource.PlayOneShot(soundEffect);
        if (other.tag == "Player")
        {
            GameManager._instance.fuel++;
            
            Destroy(this.gameObject);
        }
    }
}

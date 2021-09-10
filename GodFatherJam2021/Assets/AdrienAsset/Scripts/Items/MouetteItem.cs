using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouetteItem : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundEffect;
    public MeshRenderer mR;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mR.enabled = false;
            audioSource.PlayOneShot(soundEffect);
            GameManager._instance.FuelHit(GameManager._instance.mouetteDamage, 0.5f);
            Destroy(this.gameObject,2f);
        }
    }
}

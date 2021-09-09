using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouetteItem : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager._instance.FuelHit(GameManager._instance.mouetteDamage, 0.5f);
            Destroy(this.gameObject);
        }
    }
}

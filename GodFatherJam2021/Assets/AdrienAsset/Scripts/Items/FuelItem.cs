using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelItem : Items
{
    public int refuelNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameManager._instance.fuel < -40)
            {
                GameManager._instance.fuel -= refuelNumber;
            }
            Destroy(this.gameObject);
        }
    }
}

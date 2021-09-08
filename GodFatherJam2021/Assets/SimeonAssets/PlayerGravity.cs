using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public PlanetGravity planetAttractor;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    void FixedUpdate()
    {
        if(planetAttractor)
        {
            planetAttractor.Attract(playerTransform);
        }
    }
}

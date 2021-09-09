using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform firstPersonCam;
    public Transform topDownCam;
    public float accuranci = 2.5f;
    public bool changeCam = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = firstPersonCam.position;
        transform.rotation = firstPersonCam.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && changeCam == false)
        {
            changeCam = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && changeCam == true)
        {
            changeCam = false;
        }
    }

    private void FixedUpdate()
    {
        if (changeCam == true)
        {
            transform.position = firstPersonCam.position;
            transform.rotation = firstPersonCam.rotation;
        } else if (changeCam == false)
        {
            transform.position = topDownCam.position;
            transform.rotation = topDownCam.rotation;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform firstPersonCam;
    public Transform topDownCam;
    public float accuranci = 2.5f;
    public bool changeCam = true;

    public float lerpTime = 5f;
    private float elapsedTime = 0f;
    public float lerpSpeed = 15f;

    private Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = firstPersonCam.position;
        transform.rotation = firstPersonCam.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && changeCam == false)
        //{
        //    changeCam = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.Space) && changeCam == true)
        //{
        //    changeCam = false;
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeCam = !changeCam;
            elapsedTime = 0;
        }
    }

    private void LateUpdate()
    {
        if (changeCam == true)
        {
            targetPosition = firstPersonCam;
            LerpCamera();
            LerpRotateCamera();
        }
        else if (changeCam == false)
        {
            targetPosition = topDownCam;
            LerpCamera();
            LerpRotateCamera();
        }
    }

    private void LerpCamera()
    {
        if (transform.position == targetPosition.position) return;

        if (Vector3.Distance(transform.position, targetPosition.position) < 0.001f)
        {
            transform.position = targetPosition.position;
            //transform.rotation = targetPosition.rotation;
        }
        else
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, elapsedTime / lerpTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, targetPosition.rotation, elapsedTime / lerpTime);
        }
    }

    private void LerpRotateCamera()
    {
        if (transform.rotation == targetPosition.rotation) return;

        if (Quaternion.Angle(transform.rotation, targetPosition.rotation) < 0.001f)
        {
            transform.rotation = targetPosition.rotation;
        }
        else
        {
            elapsedTime += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetPosition.rotation, elapsedTime / lerpTime);
        }
    }
}

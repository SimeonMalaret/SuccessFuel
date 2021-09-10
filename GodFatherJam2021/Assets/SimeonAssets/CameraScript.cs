using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform firstPersonCam;
    public Transform topDownCam;
    public float accuranci = 2.5f;
    public bool changeCam = false;

    public float lerpTime = 5f;
    private float elapsedTime = 0f;
    public float lerpSpeed = 15f;

    private Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = topDownCam.position;
        transform.rotation = topDownCam.rotation;
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

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    changeCam = !changeCam;
        //    elapsedTime = 0;

        //    if (changeCam == true)
        //    {
        //        targetPosition = firstPersonCam;
        //        ChangeView(targetPosition);
        //        /*LerpCamera();
        //        LerpRotateCamera();*/
        //    }
        //    else if (changeCam == false)
        //    {
        //        targetPosition = topDownCam;
        //        ChangeView(targetPosition);
        //        /*LerpCamera();
        //        LerpRotateCamera();*/
        //}
        //}
    }

    private void FixedUpdate()
    {

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

    private void ChangeView(Transform trans)
    {
        transform.parent = trans;
        StartCoroutine(ISetPositionIn(Vector2.zero, lerpTime));
        StartCoroutine(ISetRotationIn(Quaternion.identity, lerpTime));
    }

    private IEnumerator ISetPositionIn(Vector3 position, float time)
    {
        Vector3 basePosition = transform.localPosition;
        Vector3 deltaVector = position - basePosition;
        int frameNumber = Mathf.FloorToInt(time * 60f);
        Vector3 stepVector = deltaVector / (float)frameNumber;
        //Vector3.Lerp(Vector3.zero, deltaVector, (float)i / (float)frameNumber)
        for (int i = 0; i < frameNumber; i++)
        {
            transform.localPosition += stepVector;
            yield return new WaitForSeconds(1f / 60f);
        }
    }

    private IEnumerator ISetRotationIn(Quaternion rotation, float time)
    {
        Quaternion baseRotation = transform.localRotation;
        int frameNumber = Mathf.FloorToInt(time * 60f);
        //Quaternion stepVector = deltaVector / (float)frameNumber;
        //Vector3.Lerp(Vector3.zero, deltaVector, (float)i / (float)frameNumber)
        for (int i = 0; i < frameNumber; i++)
        {
            transform.localRotation = Quaternion.Slerp(baseRotation, rotation, (float)i / (float)frameNumber);
            yield return new WaitForSeconds(1f / 60f);
        }
    }
}
